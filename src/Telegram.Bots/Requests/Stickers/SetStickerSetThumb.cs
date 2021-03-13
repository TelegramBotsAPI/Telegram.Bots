// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract record SetStickerSetThumb<TThumb> : IRequest<bool>
  {
    public string Name { get; }

    public TThumb Thumb { get; }

    public string Method { get; } = "setStickerSetThumb";

    protected SetStickerSetThumb(string name, TThumb thumb)
    {
      Name = name;
      Thumb = thumb;
    }
  }

  public sealed record SetStickerSetThumbViaUrl : SetStickerSetThumb<Uri?>
  {
    public SetStickerSetThumbViaUrl(string name, Uri? thumb = default) : base(name, thumb) { }
  }

  public sealed record SetStickerSetThumbViaCache : SetStickerSetThumb<string?>
  {
    public SetStickerSetThumbViaCache(string name, string? thumb = default) : base(name, thumb) { }
  }

  public sealed record SetStickerSetThumbViaFile : SetStickerSetThumb<InputFile?>, IUploadable
  {
    public SetStickerSetThumbViaFile(string name, InputFile? thumb = default) :
      base(name, thumb) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Thumb};
  }
}
