// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System;
using System.Collections.Generic;

public abstract record InlinePhoto<TPhoto> : ReplaceableResult, ICaptionable
{
  public override ResultType Type { get; } = ResultType.Photo;

  public TPhoto Photo { get; }

  public string? Title { get; init; }

  public string? Description { get; init; }

  public string? Caption { get; init; }

  public ParseMode? ParseMode { get; init; }

  public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

  protected InlinePhoto(string id, TPhoto photo) : base(id)
  {
    Photo = photo;
  }
}

public sealed record InlinePhoto : InlinePhoto<Uri>
{
  public Uri Thumb { get; }

  public int? Width { get; init; }

  public int? Height { get; init; }

  public InlinePhoto(string id, Uri photo, Uri thumb) : base(id, photo)
  {
    Thumb = thumb;
  }
}

public sealed record InlineCachedPhoto : InlinePhoto<string>
{
  public InlineCachedPhoto(string id, string photo) : base(id, photo) { }
}
