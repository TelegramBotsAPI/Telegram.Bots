// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;
using System.Collections.Generic;

public abstract record VideoMedia<TMedia>(
  TMedia Media) : InputMedia<TMedia>(Media), IGroupableMedia
{
  public override InputMediaType Type { get; } = InputMediaType.Video;
}

public sealed record CachedVideo : VideoMedia<string>
{
  public CachedVideo(string fileId) : base(fileId) { }
}

public sealed record VideoUrl : VideoMedia<Uri>
{
  public VideoUrl(Uri url) : base(url) { }
}

public sealed record VideoFile : VideoMedia<InputFile>, IUploadableMedia
{
  public bool? SupportsStreaming { get; init; }

  public int? Width { get; init; }

  public int? Height { get; init; }

  public int? Duration { get; init; }

  public InputFile? Thumb { get; init; }

  public bool? DisableContentTypeDetection { get; init; }

  public VideoFile(InputFile file) : base(file) { }

  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Media, Thumb
    };
  }
}
