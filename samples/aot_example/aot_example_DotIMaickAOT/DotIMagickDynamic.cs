using System.IO.Compression;
using System.Runtime.InteropServices;
using DotIMagick;

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
            byte[,,] targetArray = new byte[height, width, channel];
            long dataSize = sizeof(byte) * targetArray.LongLength;
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

            //using var image = ConvertArrayToMagickImage(targetArray);
            using var image = ConvertArrayToMagickImage(targetArray);
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
            rightHalfImage.Blur(9, 5);
            image.Composite(rightHalfImage, halfWidth, 0, CompositeOperator.Over);
        }

        public static MagickImage ConvertArrayToMagickImage(byte[,,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
            int channelCount = array.GetLength(2);
            MagickReadSettings settings = new MagickReadSettings
            {
                Width = width,
                Height = height,
                Format = channelCount == 4 ? MagickFormat.Rgba : MagickFormat.Rgb
            };

            int totalSize = height * width * channelCount;
            byte[] oneDimensionalArray = new byte[totalSize];

            // 3차원 배열의 모든 요소를 1차원 배열로 복사합니다.
            int index = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < channelCount; k++)
                    {
                        oneDimensionalArray[index++] = array[i, j, k];
                    }
                }
            }
            MagickImage image = new MagickImage(oneDimensionalArray, settings);

            return image;
        }

        public static byte[,,] ConvertMagickImageToArray(MagickImage image)
        {
            int width = image.Width;
            int height = image.Height;
            int channel;
            if (image.HasAlpha)
            {
                channel = 4;
            }
            else
            {
                channel = 3;
            }

            byte[,,] targetArray = new byte[height, width, channel];

            var imageByteArr = image.ToByteArray();

            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int z = 0; z < channel; z++)
                    {
                        targetArray[y, x, z] = imageByteArr[index++];
                    }
                }
            }

            return targetArray;
        }
    }
}
