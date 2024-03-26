// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ImageMagick;

public static class NativeConstants
{
    public const string Name = "Magick.Native";

    public const string QuantumName = Quantum + OpenMP;

    public const string X86Name = Name + "-" + QuantumName + "-x86.dll";

    public const string X64Name = Name + "-" + QuantumName + "-x64.dll";

    public const string ARM64Name = Name + "-" + QuantumName + "-arm64.dll";

#if Q8
    private const string Quantum = "Q8";
#elif Q16
    private const string Quantum = "Q16";
#elif Q16HDRI
    private const string Quantum = "Q16-HDRI";
#else
#error Not implemented!
#endif

#if OPENMP
    private const string OpenMP = "-OpenMP";
#else
    private const string OpenMP = "";
#endif

    private static string BaseLibraryPath = string.Empty;
    private static bool NativeImported = false;
    private static readonly char sep = Path.DirectorySeparatorChar;

    public static void InitBaseLibraryPath(string baseLibraryPath)
    {
        var runtimeOperatingSystemStr = string.Empty;
        if (OperatingSystem.IsWindows())
        {
            runtimeOperatingSystemStr = "win";
        }
        else if (OperatingSystem.IsLinux())
        {
            // musl을 사용하는 시스템은 특정 파일이나 경로가 존재할 수 있습니다.
            // 예를 들어, /etc/alpine-release 파일은 Alpine Linux (musl을 사용) 에서 존재합니다.
            // 다른 musl 기반 시스템을 확인하기 위한 추가적인 파일이나 조건을 추가할 수 있습니다.
            bool isAlpine = File.Exists("/etc/alpine-release");
            if (isAlpine)
            {
                runtimeOperatingSystemStr = "linux-musl";
            }
            else
            {
                runtimeOperatingSystemStr = "linux";
            }
        }
        else if (OperatingSystem.IsMacOS())
        {
            runtimeOperatingSystemStr = "osx";
        }

        BaseLibraryPath =
            baseLibraryPath
            + sep
            + "magickNativeFiles"
            + sep
            + runtimeOperatingSystemStr
            + sep;
        InitNativeLoader();
    }

    public static void InitNativeLoader()
    {
        if (NativeImported == false)
        {
            NativeLibrary.SetDllImportResolver(typeof(NativeConstants).Assembly, DllImportResolver);
            NativeImported = true;
        }
    }

    public static IntPtr DllImportResolver(
        string libraryName,
        Assembly assembly,
        DllImportSearchPath? searchPath
    )
    {
        if (libraryName == X86Name)
        {
            var currentNativeLibraryName = BaseLibraryPath + X86Name;
            return NativeLibrary.Load(currentNativeLibraryName, assembly, searchPath);
        }
        else if (libraryName == X64Name)
        {
            var currentNativeLibraryName = BaseLibraryPath + X64Name;
            return NativeLibrary.Load(currentNativeLibraryName, assembly, searchPath);
        }
        else if (libraryName == ARM64Name)
        {
            var currentNativeLibraryName = BaseLibraryPath + ARM64Name;
            return NativeLibrary.Load(currentNativeLibraryName, assembly, searchPath);
        }

        // Otherwise, fallback to default import resolver.
        return IntPtr.Zero;
    }
}
