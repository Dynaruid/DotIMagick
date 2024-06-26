﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

/// <summary>
/// Class that contains setting for the complex operation.
/// </summary>
public sealed class ComplexSettings : IComplexSettings
{
    /// <summary>
    /// Gets or sets the complex operator.
    /// </summary>
    public ComplexOperator ComplexOperator { get; set; }

    /// <summary>
    /// Gets or sets the signal to noise ratio.
    /// </summary>
    public double? SignalToNoiseRatio { get; set; }
}
