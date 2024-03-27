using DotIMagick;
using System.Runtime.InteropServices;

namespace aot_example_DotIMaickAOT
{
    public class DotIMagickDynamic
    {
        [UnmanagedCallersOnly(EntryPoint = "InitEngine")]
        public static void InitEngine(IntPtr basePathPtr)
        {
            //Console.WriteLine("initialization function is called");
            string basePath = Marshal.PtrToStringUTF8(basePathPtr)!;
            DotIMagick.NativeConstants.InitBaseLibraryPath(basePath);

            Console.WriteLine("init....done");
        }

        [UnmanagedCallersOnly(EntryPoint = "RecognizeImage")]
        public static unsafe IntPtr RecognizeImage(
            long imageArrPointer,
            int height,
            int width,
            int channel
        )
        {
            float[,,] targetArray = new float[height, width, channel];
            int dataSize = sizeof(float) * targetArray.Length;
            IntPtr inputPtr = IntPtr.Zero;
            try
            {
                inputPtr = checked((IntPtr)imageArrPointer);
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("Overflow 발생!");
            }

            if (inputPtr == IntPtr.Zero)
            {
                Console.WriteLine("이미지 데이터를 받을수 없습니다!");
                return IntPtr.Zero;
            }

            unsafe
            {
                GCHandle gch = GCHandle.Alloc(targetArray, GCHandleType.Pinned);
                try
                {
                    IntPtr dataPtr = gch.AddrOfPinnedObject();
                    // 여기에서 Buffer.MemoryCopy를 사용
                    Buffer.MemoryCopy(
                        inputPtr.ToPointer(),
                        dataPtr.ToPointer(),
                        dataSize,
                        dataSize
                    );
                }
                finally
                {
                    if (gch.IsAllocated)
                    {
                        gch.Free();
                    }
                }
            }

            var image = ConvertArrayToMagickImage(targetArray);
            MemoryStream memoryStream = new();
            image.Write(memoryStream);

            image.Dispose();
            memoryStream.Dispose();

            return inputPtr;
        }

        public static MagickImage ConvertArrayToMagickImage(float[,,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);

            Console.WriteLine("try ConvertArrayToMagickImage");

            MagickImage image = new MagickImage(MagickColors.White, width, height);
            // PixelCollection을 사용하여 이미지의 픽셀 데이터에 접근
            var pixels = image.GetPixels();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // 배열에서 RGB 값을 가져오고, 0-1 범위를 0-255 범위로 변환
                    byte r = Convert.ToByte(array[y, x, 0]);
                    byte g = Convert.ToByte(array[y, x, 1]);
                    byte b = Convert.ToByte(array[y, x, 2]);

                    byte[] color = { r, g, b, 255 }; // RGBA 형식
                    // 픽셀 색상 설정
                    pixels.SetPixel(x, y, color);
                }
            }

            image.Format = MagickFormat.Tiff;

            return image;
        }
    }
}
