using DotIMagick;
using System.Runtime.InteropServices;

namespace aot_example_DotIMaickAOT
{
    public class DotIMagickDynamic
    {
        [UnmanagedCallersOnly(EntryPoint = "InitEngine")]
        public static void InitEngine(IntPtr basePathPtr)
        {
            string basePath = Marshal.PtrToStringUTF8(basePathPtr)!;
            DotIMagick.NativeConstants.InitBaseLibraryPath(basePath);
        }

        [UnmanagedCallersOnly(EntryPoint = "RunDemoBulrRightHalfImage")]
        public static unsafe void RunDemoBulrRightHalfImage(
            long imageArrPointer,
            int height,
            int width,
            int channel
        )
        {
            float[,,] targetArray = new float[height, width, channel];
            int dataSize = sizeof(float) * targetArray.Length;
            IntPtr imagePtr = IntPtr.Zero;
            try
            {
                imagePtr = checked((IntPtr)imageArrPointer);
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("Overflow 발생!");
            }

            if (imagePtr == IntPtr.Zero)
            {
                Console.WriteLine("이미지 데이터를 받을수 없습니다!");
                //return IntPtr.Zero;
            }

            unsafe
            {
                GCHandle gch = GCHandle.Alloc(targetArray, GCHandleType.Pinned);
                try
                {
                    IntPtr dataPtr = gch.AddrOfPinnedObject();

                    Buffer.MemoryCopy(
                        imagePtr.ToPointer(),
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

            BlurRightHalfOfImage(image);

            targetArray = ConvertMagickImageToArray(image);

            unsafe
            {
                GCHandle gch = GCHandle.Alloc(targetArray, GCHandleType.Pinned);
                try
                {
                    IntPtr dataPtr = gch.AddrOfPinnedObject();
                    // 여기에서 Buffer.MemoryCopy를 사용
                    Buffer.MemoryCopy(
                        dataPtr.ToPointer(),
                        imagePtr.ToPointer(),
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

            image.Dispose();

            //return inputPtr;
        }

        public static void BlurRightHalfOfImage(MagickImage image)
        {
            using MagickImage rightHalfImage = (MagickImage)image.Clone();
            int halfWidth = rightHalfImage.Width / 2;

            // 가로로 절반으로 자르기
            MagickGeometry size = new MagickGeometry(halfWidth, 0, halfWidth, rightHalfImage.Height)
            {
                IgnoreAspectRatio = true
            };

            rightHalfImage.Crop(size);
            rightHalfImage.GaussianBlur(9, 10);
            image.Composite(rightHalfImage, halfWidth, 0, CompositeOperator.Over);
        }

        public static MagickImage ConvertArrayToMagickImage(float[,,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);

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

        public static float[,,] ConvertMagickImageToArray(MagickImage image)
        {
            int width = image.Width;
            int height = image.Height;
            int channel = 4; // RGB 채널만 고려

            float[,,] targetArray = new float[height, width, channel];

            // PixelCollection을 사용하여 이미지의 픽셀 데이터에 접근
            var pixels = image.GetPixels();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // RGBA 형식의 픽셀 데이터에서 RGB 값을 추출하고, 0-255 범위를 0-1 범위로 변환
                    var pixel = pixels.GetPixel(x, y).ToColor()!;
                    targetArray[y, x, 0] = pixel.R / 255f; // R
                    targetArray[y, x, 1] = pixel.G / 255f; // G
                    targetArray[y, x, 2] = pixel.B / 255f; // B
                    targetArray[y, x, 3] = 255;
                }
            }

            return targetArray;
        }
    }
}
