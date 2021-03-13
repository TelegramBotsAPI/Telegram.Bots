// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public abstract record DocumentMedia<TMedia> : InputMedia<TMedia>, IGroupableMedia
  {
    public override InputMediaType Type { get; } = InputMediaType.Document;

    protected DocumentMedia(TMedia media) : base(media) { }
  }

  public sealed record CachedDocument : DocumentMedia<string>
  {
    public CachedDocument(string fileId) : base(fileId) { }
  }

  public sealed record DocumentUrl : DocumentMedia<Uri>
  {
    public DocumentUrl(Uri url) : base(url) { }
  }

  public sealed record DocumentFile : DocumentMedia<InputFile>, IUploadableMedia
  {
    public InputFile? Thumb { get; init; }

    public bool? DisableContentTypeDetection { get; init; }

    public DocumentFile(InputFile file) : base(file) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Media, Thumb};
  }
}
