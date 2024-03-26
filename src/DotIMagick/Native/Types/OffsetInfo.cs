// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace DotIMagick;

internal partial class OffsetInfo
{
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
#if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OffsetInfo_Create();
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_Dispose(IntPtr instance);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_SetX(IntPtr Instance, IntPtr value);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_SetY(IntPtr Instance, IntPtr value);
        }
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OffsetInfo_Create();
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_Dispose(IntPtr instance);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_SetX(IntPtr Instance, IntPtr value);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_SetY(IntPtr Instance, IntPtr value);
        }
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OffsetInfo_Create();
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_Dispose(IntPtr instance);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_SetX(IntPtr Instance, IntPtr value);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OffsetInfo_SetY(IntPtr Instance, IntPtr value);
        }
#endif
    }
    private unsafe sealed partial class NativeOffsetInfo : NativeInstance
    {
        static NativeOffsetInfo() { Environment.Initialize(); }
        protected override void Dispose(IntPtr instance)
        {
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.OffsetInfo_Dispose(instance);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OffsetInfo_Dispose(instance);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OffsetInfo_Dispose(instance);
#endif
        }
        public NativeOffsetInfo()
        {
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                Instance = NativeMethods.ARM64.OffsetInfo_Create();
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.OffsetInfo_Create();
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.OffsetInfo_Create();
#endif
            if (Instance == IntPtr.Zero)
                throw new InvalidOperationException();
        }
        protected override string TypeName
        {
            get
            {
                return nameof(OffsetInfo);
            }
        }
        public void SetX(int value)
        {
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.OffsetInfo_SetX(Instance, (IntPtr)value);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OffsetInfo_SetX(Instance, (IntPtr)value);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OffsetInfo_SetX(Instance, (IntPtr)value);
#endif
        }
        public void SetY(int value)
        {
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.OffsetInfo_SetY(Instance, (IntPtr)value);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OffsetInfo_SetY(Instance, (IntPtr)value);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OffsetInfo_SetY(Instance, (IntPtr)value);
#endif
        }
    }
    internal static INativeInstance CreateInstance(OffsetInfo? instance)
    {
        if (instance is null)
            return NativeInstance.Zero;
        return instance.CreateNativeInstance();
    }
}
