﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

/// <summary>
/// Encapsulation of the ImageMagick StreamWarning exception.
/// </summary>
public sealed class MagickStreamWarningException : MagickWarningException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MagickStreamWarningException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public MagickStreamWarningException(string message)
        : base(message) { }
}
