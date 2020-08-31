// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract class AudioMedia<TMedia> : InputMedia<TMedia>
  {
    public override InputMediaType Type { get; } = InputMediaType.Audio;

    protected AudioMedia(TMedia media) : base(media) { }
  }

  public sealed class CachedAudio : AudioMedia<string>
  {
    public CachedAudio(string fileId) : base(fileId) { }
  }

  public sealed class AudioUrl : AudioMedia<Uri>
  {
    public AudioUrl(Uri url) : base(url) { }
  }

  public sealed class AudioFile : AudioMedia<InputFile>, IUploadableMedia
  {
    public int? Duration { get; set; }

    public string? Performer { get; set; }

    public string? Title { get; set; }

    public InputFile? Thumb { get; set; }

    public AudioFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media, Thumb };
  }
}
