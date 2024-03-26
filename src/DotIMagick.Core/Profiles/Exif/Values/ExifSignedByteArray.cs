// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace DotIMagick;

internal sealed class ExifSignedByteArray : ExifArrayValue<sbyte>
{
    public ExifSignedByteArray(ExifTagValue tag)
        : base(tag) { }

    public override ExifDataType DataType => ExifDataType.SignedByte;
}
