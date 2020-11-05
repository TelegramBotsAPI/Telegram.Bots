// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlinePhoto<TPhoto> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Photo;

    public TPhoto Photo { get; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    protected InlinePhoto(string id, TPhoto photo) : base(id) => Photo = photo;
  }

  public sealed class InlinePhoto : InlinePhoto<Uri>
  {
    public Uri Thumb { get; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public InlinePhoto(string id, Uri photo, Uri thumb) : base(id, photo) => Thumb = thumb;
  }

  public sealed class InlineCachedPhoto : InlinePhoto<string>
  {
    public InlineCachedPhoto(string id, string photo) : base(id, photo) { }
  }
}
