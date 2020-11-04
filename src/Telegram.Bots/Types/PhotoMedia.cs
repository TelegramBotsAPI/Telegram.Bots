// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract class PhotoMedia<TMedia> : InputMedia<TMedia>, IGroupableMedia
  {
    public override InputMediaType Type { get; } = InputMediaType.Photo;

    protected PhotoMedia(TMedia media) : base(media) { }
  }

  public sealed class CachedPhoto : PhotoMedia<string>
  {
    public CachedPhoto(string fileId) : base(fileId) { }
  }

  public sealed class PhotoUrl : PhotoMedia<Uri>
  {
    public PhotoUrl(Uri url) : base(url) { }
  }

  public sealed class PhotoFile : PhotoMedia<InputFile>, IUploadableMedia
  {
    public PhotoFile(InputFile file) : base(file) { }

    public bool? DisableContentTypeDetection { get; set; }

    public IEnumerable<InputFile?> GetFiles() => new[] { Media };
  }
}
