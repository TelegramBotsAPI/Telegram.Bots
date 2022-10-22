// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public abstract record InlineVideo<TVideo> : ReplaceableResult, ICaptionable
{
  public override ResultType Type { get; } = ResultType.Video;

  public TVideo Video { get; }

  public string Title { get; }

  public string? Description { get; init; }

  public string? Caption { get; init; }

  public ParseMode? ParseMode { get; init; }

  public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

  protected InlineVideo(string id, string title, TVideo video) : base(id)
  {
    Title = title;
    Video = video;
  }
}

public sealed record InlineVideo : InlineVideo<Uri>
{
  public VideoMimeType MimeType { get; }

  public Uri Thumb { get; }

  public int? Width { get; init; }

  public int? Height { get; init; }

  public int? Duration { get; init; }

  public InlineVideo(
    string id,
    string title,
    Uri video,
    VideoMimeType mimeType,
    Uri thumb) :
    base(id, title, video)
  {
    MimeType = mimeType;
    Thumb = thumb;
  }
}

public sealed record InlineCachedVideo : InlineVideo<string>
{
  public InlineCachedVideo(string id, string title, string video) : base(id,
    title, video) { }
}

public enum VideoMimeType
{
  [EnumMember(Value = "text/html")]
  Html,

  [EnumMember(Value = "video/mp4")]
  Video
}
