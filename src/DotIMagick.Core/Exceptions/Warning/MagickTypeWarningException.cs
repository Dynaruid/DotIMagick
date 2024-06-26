﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

/// <summary>
/// Encapsulation of the ImageMagick TypeWarning exception.
/// </summary>
public sealed class MagickTypeWarningException : MagickWarningException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MagickTypeWarningException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public MagickTypeWarningException(string message)
        : base(message) { }
}
