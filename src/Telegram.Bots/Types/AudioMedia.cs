// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract record AudioMedia<TMedia> : InputMedia<TMedia>, IGroupableMedia
  {
    public override InputMediaType Type { get; } = InputMediaType.Audio;

    protected AudioMedia(TMedia media) : base(media) { }
  }

  public sealed record CachedAudio : AudioMedia<string>
  {
    public CachedAudio(string fileId) : base(fileId) { }
  }

  public sealed record AudioUrl : AudioMedia<Uri>
  {
    public AudioUrl(Uri url) : base(url) { }
  }

  public sealed record AudioFile : AudioMedia<InputFile>, IUploadableMedia
  {
    public int? Duration { get; init; }

    public string? Performer { get; init; }

    public string? Title { get; init; }

    public InputFile? Thumb { get; init; }

    public bool? DisableContentTypeDetection { get; init; }

    public AudioFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media, Thumb };
  }
}
