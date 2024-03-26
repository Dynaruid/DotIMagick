// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace DotIMagick;

public partial class OpenCLDevice
{
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
#if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double OpenCLDevice_BenchmarkScore_Get(IntPtr instance);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern UIntPtr OpenCLDevice_DeviceType_Get(IntPtr instance);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool OpenCLDevice_IsEnabled_Get(IntPtr instance);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenCLDevice_IsEnabled_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_Name_Get(IntPtr instance);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_Version_Get(IntPtr instance);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_GetKernelProfileRecords(IntPtr Instance, out UIntPtr length);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_GetKernelProfileRecord(IntPtr list, UIntPtr index);
            [DllImport(NativeConstants.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenCLDevice_SetProfileKernels(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        }
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double OpenCLDevice_BenchmarkScore_Get(IntPtr instance);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern UIntPtr OpenCLDevice_DeviceType_Get(IntPtr instance);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool OpenCLDevice_IsEnabled_Get(IntPtr instance);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenCLDevice_IsEnabled_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_Name_Get(IntPtr instance);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_Version_Get(IntPtr instance);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_GetKernelProfileRecords(IntPtr Instance, out UIntPtr length);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_GetKernelProfileRecord(IntPtr list, UIntPtr index);
            [DllImport(NativeConstants.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenCLDevice_SetProfileKernels(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        }
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double OpenCLDevice_BenchmarkScore_Get(IntPtr instance);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern UIntPtr OpenCLDevice_DeviceType_Get(IntPtr instance);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool OpenCLDevice_IsEnabled_Get(IntPtr instance);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenCLDevice_IsEnabled_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_Name_Get(IntPtr instance);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_Version_Get(IntPtr instance);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_GetKernelProfileRecords(IntPtr Instance, out UIntPtr length);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr OpenCLDevice_GetKernelProfileRecord(IntPtr list, UIntPtr index);
            [DllImport(NativeConstants.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void OpenCLDevice_SetProfileKernels(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        }
#endif
    }
    private unsafe sealed partial class NativeOpenCLDevice : ConstNativeInstance
    {
        static NativeOpenCLDevice() { Environment.Initialize(); }
        protected override string TypeName
        {
            get
            {
                return nameof(OpenCLDevice);
            }
        }
        public double BenchmarkScore
        {
            get
            {
                double result;
#if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.OpenCLDevice_BenchmarkScore_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLDevice_BenchmarkScore_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLDevice_BenchmarkScore_Get(Instance);
#endif
                return result;
            }
        }
        public OpenCLDeviceType DeviceType
        {
            get
            {
                UIntPtr result;
#if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.OpenCLDevice_DeviceType_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLDevice_DeviceType_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLDevice_DeviceType_Get(Instance);
#endif
                return (OpenCLDeviceType)result;
            }
        }
        public bool IsEnabled
        {
            get
            {
                bool result;
#if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.OpenCLDevice_IsEnabled_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLDevice_IsEnabled_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLDevice_IsEnabled_Get(Instance);
#endif
                return result;
            }
            set
            {
#if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.OpenCLDevice_IsEnabled_Set(Instance, value);
#endif
#if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.OpenCLDevice_IsEnabled_Set(Instance, value);
#endif
#if PLATFORM_AnyCPU
                else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.OpenCLDevice_IsEnabled_Set(Instance, value);
#endif
            }
        }
        public string Name
        {
            get
            {
                IntPtr result;
#if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.OpenCLDevice_Name_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLDevice_Name_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLDevice_Name_Get(Instance);
#endif
                return UTF8Marshaler.NativeToManaged(result);
            }
        }
        public string Version
        {
            get
            {
                IntPtr result;
#if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.OpenCLDevice_Version_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLDevice_Version_Get(Instance);
#endif
#if PLATFORM_AnyCPU
                else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLDevice_Version_Get(Instance);
#endif
                return UTF8Marshaler.NativeToManaged(result);
            }
        }
        public IntPtr GetKernelProfileRecords(out UIntPtr length)
        {
            IntPtr result;
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.OpenCLDevice_GetKernelProfileRecords(Instance, out length);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.OpenCLDevice_GetKernelProfileRecords(Instance, out length);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.OpenCLDevice_GetKernelProfileRecords(Instance, out length);
#endif
            return result;
        }
        public static IntPtr GetKernelProfileRecord(IntPtr list, int index)
        {
            IntPtr result;
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.OpenCLDevice_GetKernelProfileRecord(list, (UIntPtr)index);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.OpenCLDevice_GetKernelProfileRecord(list, (UIntPtr)index);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.OpenCLDevice_GetKernelProfileRecord(list, (UIntPtr)index);
#endif
            return result;
        }
        public void SetProfileKernels(bool value)
        {
#if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
#endif
#if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.OpenCLDevice_SetProfileKernels(Instance, value);
#endif
#if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
#endif
#if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OpenCLDevice_SetProfileKernels(Instance, value);
#endif
#if PLATFORM_AnyCPU
            else
#endif
#if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OpenCLDevice_SetProfileKernels(Instance, value);
#endif
        }
    }
}
