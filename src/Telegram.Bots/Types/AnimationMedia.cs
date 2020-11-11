// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract record AnimationMedia<TMedia> : InputMedia<TMedia>
  {
    public override InputMediaType Type { get; } = InputMediaType.Animation;

    protected AnimationMedia(TMedia media) : base(media) { }
  }

  public sealed record CachedAnimation : AnimationMedia<string>
  {
    public CachedAnimation(string fileId) : base(fileId) { }
  }

  public sealed record AnimationUrl : AnimationMedia<Uri>
  {
    public AnimationUrl(Uri url) : base(url) { }
  }

  public sealed record AnimationFile : AnimationMedia<InputFile>, IUploadableMedia
  {
    public int? Duration { get; init; }

    public int? Width { get; init; }

    public int? Height { get; init; }

    public InputFile? Thumb { get; init; }

    public bool? DisableContentTypeDetection { get; init; }

    public AnimationFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media, Thumb };
  }
}
