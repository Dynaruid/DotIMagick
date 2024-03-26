// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;

namespace DotIMagick;

/// <summary>
/// Draws a set of paths.
/// </summary>
public interface IDrawablePath : IDrawable
{
    /// <summary>
    /// Gets the paths to use.
    /// </summary>
    IReadOnlyCollection<IPath> Paths { get; }
}
