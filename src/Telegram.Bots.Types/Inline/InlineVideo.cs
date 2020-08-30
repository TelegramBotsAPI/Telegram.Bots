// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Runtime.Serialization;

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineVideo<TVideo> : ReplaceableResult
  {
    public override ResultType Type { get; } = ResultType.Video;

    public TVideo Video { get; }

    public string Title { get; }

    public string? Description { get; set; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    protected InlineVideo(string id, string title, TVideo video) : base(id)
    {
      Title = title;
      Video = video;
    }
  }

  public sealed class InlineVideo : InlineVideo<Uri>
  {
    public VideoMimeType MimeType { get; }

    public Uri Thumb { get; }

    public int? Width { get; set; }

    public int? Height { get; set; }

    public int? Duration { get; set; }

    public InlineVideo(string id, string title, Uri video, VideoMimeType mimeType, Uri thumb) :
      base(id, title, video)
    {
      MimeType = mimeType;
      Thumb = thumb;
    }
  }

  public sealed class InlineCachedVideo : InlineVideo<string>
  {
    public InlineCachedVideo(string id, string title, string video) : base(id, title, video) { }
  }

  public enum VideoMimeType
  {
    [EnumMember(Value = "text/html")] Html,
    [EnumMember(Value = "video/mp4")] Video
  }
}
