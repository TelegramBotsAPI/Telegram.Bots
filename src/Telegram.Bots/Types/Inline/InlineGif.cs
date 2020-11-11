// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Inline
{
  public abstract record InlineGif<TGif> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Gif;

    public TGif Gif { get; }

    public string? Title { get; init; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    protected InlineGif(string id, TGif gif) : base(id) => Gif = gif;
  }

  public sealed record InlineGif : InlineGif<Uri>
  {
    public int? Width { get; init; }

    public int? Height { get; init; }

    public int? Duration { get; init; }

    public Uri Thumb { get; }

    public ThumbMimeType? ThumbMimeType { get; init; }

    public InlineGif(string id, Uri gif, Uri thumb) : base(id, gif) => Thumb = thumb;
  }

  public sealed record InlineCachedGif : InlineGif<string>
  {
    public InlineCachedGif(string id, string gif) : base(id, gif) { }
  }
}
