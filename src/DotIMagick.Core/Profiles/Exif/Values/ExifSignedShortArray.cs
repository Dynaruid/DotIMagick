// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

internal sealed class ExifSignedShortArray : ExifArrayValue<short>
{
    public ExifSignedShortArray(ExifTagValue tag)
        : base(tag) { }

    public override ExifDataType DataType => ExifDataType.SignedShort;
}
