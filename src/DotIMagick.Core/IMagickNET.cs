﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.IO;

namespace DotIMagick;

/// <summary>
/// Interface that represents MagickNET.
/// </summary>
public interface IMagickNET
{
    /// <summary>
    /// Event that will be raised when something is logged by DotIMagick.
    /// </summary>
    event EventHandler<LogEventArgs> Log;

    /// <summary>
    /// Gets the ImageMagick delegate libraries.
    /// </summary>
    string Delegates { get; }

    /// <summary>
    /// Gets the ImageMagick features.
    /// </summary>
    string Features { get; }

    /// <summary>
    /// Gets the font families that are known by DotIMagick.
    /// </summary>
    IReadOnlyCollection<string> FontFamilies { get; }

    /// <summary>
    /// Gets the font names that are known by DotIMagick.
    /// </summary>
    IReadOnlyCollection<string> FontNames { get; }

    /// <summary>
    /// Gets the version of DotIMagick.
    /// </summary>
    string ImageMagickVersion { get; }

    /// <summary>
    /// Gets information about the supported formats.
    /// </summary>
    IReadOnlyCollection<IMagickFormatInfo> SupportedFormats { get; }

    /// <summary>
    /// Gets the version of Magick.NET.
    /// </summary>
    string Version { get; }

    /// <summary>
    /// Gets the environment variable with the specified name.
    /// </summary>
    /// <param name="name">The name of the environment variable.</param>
    /// <returns>The environment variable with the specified name.</returns>
    string? GetEnvironmentVariable(string name);

    /// <summary>
    /// Initializes DotIMagick.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Resets the pseudo-random number generator secret key.
    /// </summary>
    void ResetRandomSeed();

    /// <summary>
    /// Set the path to the default font file.
    /// </summary>
    /// <param name="file">The file to use at the default font file.</param>
    void SetDefaultFontFile(FileInfo file);

    /// <summary>
    /// Set the path to the default font file.
    /// </summary>
    /// <param name="fileName">The file name to use at the default font file.</param>
    void SetDefaultFontFile(string fileName);

    /// <summary>
    /// Set the environment variable with the specified name to the specified value.
    /// </summary>
    /// <param name="name">The name of the environment variable.</param>
    /// <param name="value">The value of the environment variable.</param>
    void SetEnvironmentVariable(string name, string value);

    /// <summary>
    /// Sets the directory that contains the FontConfig configuration files.
    /// </summary>
    /// <param name="path">The path of the FontConfig directory.</param>
    void SetFontConfigDirectory(string path);

    /// <summary>
    /// Sets the directory that contains the Ghostscript file gsdll32.dll / gsdll64.dll.
    /// This method is only supported on Windows.
    /// </summary>
    /// <param name="path">The path of the Ghostscript directory.</param>
    void SetGhostscriptDirectory(string path);

    /// <summary>
    /// Sets the directory that contains the Ghostscript font files.
    /// This method is only supported on Windows.
    /// </summary>
    /// <param name="path">The path of the Ghostscript font directory.</param>
    void SetGhostscriptFontDirectory(string path);

    /// <summary>
    /// Set the events that will be written to the log. The log will be written to the Log event
    /// and the debug window in VisualStudio. To change the log settings you must use a custom
    /// log.xml file.
    /// </summary>
    /// <param name="events">The events that will be logged.</param>
    void SetLogEvents(LogEvents events);

    /// <summary>
    /// Sets the directory that contains the Native library. This currently only works on Windows.
    /// </summary>
    /// <param name="path">The path of the directory that contains the native library.</param>
    void SetNativeLibraryDirectory(string path);

    /// <summary>
    /// Sets the directory that will be used when ImageMagick does not have enough memory for the
    /// pixel cache.
    /// </summary>
    /// <param name="path">The path where temp files will be written.</param>
    void SetTempDirectory(string path);

    /// <summary>
    /// Sets the pseudo-random number generator secret key.
    /// </summary>
    /// <param name="seed">The secret key.</param>
    void SetRandomSeed(int seed);
}
