// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace DotIMagick.ImageOptimizers;

public partial class JpegOptimizer
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate long ReadWriteStreamDelegate(IntPtr data, UIntPtr length, IntPtr user_data);
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
#if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void JpegOptimizer_CompressFile(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality, out IntPtr exception);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void JpegOptimizer_CompressStream(ReadWriteStreamDelegate? reader, ReadWriteStreamDelegate? writer, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality, out IntPtr exception);
        }
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void JpegOptimizer_CompressFile(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality, out IntPtr exception);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void JpegOptimizer_CompressStream(ReadWriteStreamDelegate? reader, ReadWriteStreamDelegate? writer, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality, out IntPtr exception);
        }
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void JpegOptimizer_CompressFile(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality, out IntPtr exception);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void JpegOptimizer_CompressStream(ReadWriteStreamDelegate? reader, ReadWriteStreamDelegate? writer, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality, out IntPtr exception);
        }
#endif
    }
    private unsafe sealed partial class NativeJpegOptimizer : NativeHelper
    {
        static NativeJpegOptimizer() { Environment.Initialize(); }
        public void CompressFile(string input, string output, bool progressive, bool lossless, int quality)
        {
            using var inputNative = UTF8Marshaler.CreateInstance(input);
            using var outputNative = UTF8Marshaler.CreateInstance(output);
            IntPtr exception = IntPtr.Zero;
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.JpegOptimizer_CompressFile(inputNative.Instance, outputNative.Instance, progressive, lossless, (UIntPtr)quality, out exception);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.JpegOptimizer_CompressFile(inputNative.Instance, outputNative.Instance, progressive, lossless, (UIntPtr)quality, out exception);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.JpegOptimizer_CompressFile(inputNative.Instance, outputNative.Instance, progressive, lossless, (UIntPtr)quality, out exception);
#endif
            CheckException(exception);
        }
        public void CompressStream(ReadWriteStreamDelegate reader, ReadWriteStreamDelegate writer, bool progressive, bool lossless, int quality)
        {
            IntPtr exception = IntPtr.Zero;
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.JpegOptimizer_CompressStream(reader, writer, progressive, lossless, (UIntPtr)quality, out exception);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.JpegOptimizer_CompressStream(reader, writer, progressive, lossless, (UIntPtr)quality, out exception);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.JpegOptimizer_CompressStream(reader, writer, progressive, lossless, (UIntPtr)quality, out exception);
#endif
            CheckException(exception);
        }
    }
}
