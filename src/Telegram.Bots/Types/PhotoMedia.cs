// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;
using System.Collections.Generic;

public abstract record PhotoMedia<TMedia> : InputMedia<TMedia>, IGroupableMedia
{
  public override InputMediaType Type => InputMediaType.Photo;

  protected PhotoMedia(TMedia media) : base(media) { }
}

public sealed record CachedPhoto : PhotoMedia<string>
{
  public CachedPhoto(string fileId) : base(fileId) { }
}

public sealed record PhotoUrl : PhotoMedia<Uri>
{
  public PhotoUrl(Uri url) : base(url) { }
}

public sealed record PhotoFile : PhotoMedia<InputFile>, IUploadableMedia
{
  public PhotoFile(InputFile file) : base(file) { }

  public bool? DisableContentTypeDetection { get; init; }

  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Media
    };
  }
}
