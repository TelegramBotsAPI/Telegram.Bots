// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Inline
{
  public abstract record InlineMpeg4Gif<TMpeg4> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Mpeg4Gif;

    public TMpeg4 Mpeg4 { get; }

    public string? Title { get; init; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    protected InlineMpeg4Gif(string id, TMpeg4 mpeg4) : base(id) => Mpeg4 = mpeg4;
  }

  public sealed record InlineMpeg4Gif : InlineMpeg4Gif<Uri>
  {
    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public Uri Thumb { get; }

    public ThumbMimeType? ThumbMimeType { get; init; }

    public InlineMpeg4Gif(string id, Uri mpeg4, Uri thumb) : base(id, mpeg4) => Thumb = thumb;
  }

  public sealed record InlineCachedMpeg4Gif : InlineMpeg4Gif<string>
  {
    public InlineCachedMpeg4Gif(string id, string mpeg4) : base(id, mpeg4) { }
  }
}
