﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;

namespace DotIMagick;

/// <summary>
/// Interface that represents the OpenCL information of DotIMagick.
/// </summary>
public interface IOpenCL
{
    /// <summary>
    /// Gets or sets a value indicating whether OpenCL is enabled.
    /// </summary>
    bool IsEnabled { get; set; }

    /// <summary>
    /// Gets all the OpenCL devices.
    /// </summary>
    /// <returns>A <see cref="IOpenCLDevice"/> iteration.</returns>
    IReadOnlyCollection<IOpenCLDevice> Devices { get; }

    /// <summary>
    /// Sets the directory that will be used by ImageMagick to store OpenCL cache files.
    /// </summary>
    /// <param name="path">The path of the OpenCL cache directory.</param>
    void SetCacheDirectory(string path);
}
