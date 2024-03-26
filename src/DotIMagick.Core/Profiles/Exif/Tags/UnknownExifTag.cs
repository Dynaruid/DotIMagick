// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

internal sealed class UnknownExifTag : ExifTag
{
    internal UnknownExifTag(ExifTagValue value)
        : base((ushort)value) { }
}
