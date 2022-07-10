// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    internal static partial class MagickExceptionHelper
    {
        [SuppressUnmanagedCodeSecurity]
        private static unsafe class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Description(IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickExceptionHelper_Dispose(IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Message(IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Related(IntPtr exception, UIntPtr index);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickExceptionHelper_RelatedCount(IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickExceptionHelper_Severity(IntPtr exception);
            }
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            public static class ARM64
            {
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Description(IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickExceptionHelper_Dispose(IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Message(IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Related(IntPtr exception, UIntPtr index);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickExceptionHelper_RelatedCount(IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickExceptionHelper_Severity(IntPtr exception);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Description(IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickExceptionHelper_Dispose(IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Message(IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickExceptionHelper_Related(IntPtr exception, UIntPtr index);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickExceptionHelper_RelatedCount(IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickExceptionHelper_Severity(IntPtr exception);
            }
            #endif
        }
        private unsafe static class NativeMagickExceptionHelper
        {
            static NativeMagickExceptionHelper() { Environment.Initialize(); }
            public static string? Description(IntPtr exception)
            {
                IntPtr result;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.MagickExceptionHelper_Description(exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.MagickExceptionHelper_Description(exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.MagickExceptionHelper_Description(exception);
                #endif
                return UTF8Marshaler.NativeToManagedNullable(result);
            }
            public static void Dispose(IntPtr exception)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.MagickExceptionHelper_Dispose(exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.MagickExceptionHelper_Dispose(exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.MagickExceptionHelper_Dispose(exception);
                #endif
            }
            public static string? Message(IntPtr exception)
            {
                IntPtr result;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.MagickExceptionHelper_Message(exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.MagickExceptionHelper_Message(exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.MagickExceptionHelper_Message(exception);
                #endif
                return UTF8Marshaler.NativeToManagedNullable(result);
            }
            public static IntPtr Related(IntPtr exception, int index)
            {
                IntPtr result;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.MagickExceptionHelper_Related(exception, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.MagickExceptionHelper_Related(exception, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.MagickExceptionHelper_Related(exception, (UIntPtr)index);
                #endif
                return result;
            }
            public static int RelatedCount(IntPtr exception)
            {
                UIntPtr result;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.MagickExceptionHelper_RelatedCount(exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.MagickExceptionHelper_RelatedCount(exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.MagickExceptionHelper_RelatedCount(exception);
                #endif
                return (int)result;
            }
            public static int Severity(IntPtr exception)
            {
                UIntPtr result;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.MagickExceptionHelper_Severity(exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.MagickExceptionHelper_Severity(exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.MagickExceptionHelper_Severity(exception);
                #endif
                return (int)result;
            }
        }
    }
}
