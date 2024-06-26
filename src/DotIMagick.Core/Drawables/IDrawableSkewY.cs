// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

/// <summary>
/// Skews the current coordinate system in the vertical direction.
/// </summary>
public interface IDrawableSkewY : IDrawable
{
    /// <summary>
    /// Gets the angle.
    /// </summary>
    double Angle { get; }
}
