// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

using System;
using System.Collections.Generic;
using Types;

public abstract record SetStickerSetThumb<TThumb>(
  string Name,
  TThumb Thumb) : IRequest<bool>
{
  public string Method => "setStickerSetThumb";
}

public sealed record SetStickerSetThumbViaUrl(
  string Name,
  Uri? Thumb = default) : SetStickerSetThumb<Uri?>(Name, Thumb);

public sealed record SetStickerSetThumbViaCache(
  string Name,
  string? Thumb = default) : SetStickerSetThumb<string?>(Name, Thumb);

public sealed record SetStickerSetThumbViaFile(
  string Name,
  InputFile? Thumb = default) : SetStickerSetThumb<InputFile?>(Name, Thumb),
  IUploadable
{
  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Thumb
    };
  }
}
