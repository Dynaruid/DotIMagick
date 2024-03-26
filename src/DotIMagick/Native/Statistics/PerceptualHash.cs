// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace DotIMagick;

public partial class PerceptualHash
{
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
#if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PerceptualHash_DisposeList(IntPtr list);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr PerceptualHash_GetInstance(IntPtr image, IntPtr list, UIntPtr channel);
        }
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PerceptualHash_DisposeList(IntPtr list);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr PerceptualHash_GetInstance(IntPtr image, IntPtr list, UIntPtr channel);
        }
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void PerceptualHash_DisposeList(IntPtr list);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr PerceptualHash_GetInstance(IntPtr image, IntPtr list, UIntPtr channel);
        }
#endif
    }
    private unsafe static partial class NativePerceptualHash
    {
        static NativePerceptualHash() { Environment.Initialize(); }
        public static void DisposeList(IntPtr list)
        {
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.PerceptualHash_DisposeList(list);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.PerceptualHash_DisposeList(list);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.PerceptualHash_DisposeList(list);
#endif
        }
        public static IntPtr GetInstance(IMagickImage image, IntPtr list, PixelChannel channel)
        {
            IntPtr result;
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.PerceptualHash_GetInstance(MagickImage.GetInstance(image), list, (UIntPtr)channel);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.PerceptualHash_GetInstance(MagickImage.GetInstance(image), list, (UIntPtr)channel);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.PerceptualHash_GetInstance(MagickImage.GetInstance(image), list, (UIntPtr)channel);
#endif
            return result;
        }
    }
}
