// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineMpeg4Gif<TMpeg4> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Mpeg4Gif;

    public TMpeg4 Mpeg4 { get; }

    public string? Title { get; set; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    protected InlineMpeg4Gif(string id, TMpeg4 mpeg4) : base(id) => Mpeg4 = mpeg4;
  }

  public sealed class InlineMpeg4Gif : InlineMpeg4Gif<Uri>
  {
    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Duration { get; set; }

    public Uri Thumb { get; }

    public ThumbMimeType? ThumbMimeType { get; set; }

    public InlineMpeg4Gif(string id, Uri mpeg4, Uri thumb) : base(id, mpeg4) => Thumb = thumb;
  }

  public sealed class InlineCachedMpeg4Gif : InlineMpeg4Gif<string>
  {
    public InlineCachedMpeg4Gif(string id, string mpeg4) : base(id, mpeg4) { }
  }
}
