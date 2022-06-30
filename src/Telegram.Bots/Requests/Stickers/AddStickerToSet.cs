// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

using System;
using System.Collections.Generic;
using Types;
using Types.Stickers;

public abstract record AddStickerToSetBase(
  long UserId,
  string Name,
  string Emojis) : IRequest<bool>, IUserTargetable
{
  public MaskPosition? MaskPosition { get; init; }

  public string Method => "addStickerToSet";
}

public abstract record AddStickerToSet<TPngSticker>(
  long UserId,
  string Name,
  string Emojis,
  TPngSticker Sticker) : AddStickerToSetBase(UserId, Name, Emojis);

public sealed record AddStickerToSetViaCache(
  long UserId,
  string Name,
  string Emojis,
  string Sticker) : AddStickerToSet<string>(UserId, Name, Emojis, Sticker);

public sealed record AddStickerToSetViaUrl(
  long UserId,
  string Name,
  string Emojis,
  Uri Sticker) : AddStickerToSet<Uri>(UserId, Name, Emojis, Sticker);

public sealed record AddStickerToSetViaFile(
  long UserId,
  string Name,
  string Emojis,
  InputFile Sticker) :
  AddStickerToSet<InputFile>(UserId, Name, Emojis, Sticker),
  IUploadable
{
  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Sticker
    };
  }
}

public abstract record AddAnimatedStickerToSet<TTgsSticker>(
  long UserId,
  string Name,
  string Emojis,
  TTgsSticker Sticker) : AddStickerToSetBase(UserId, Name, Emojis);

public sealed record AddAnimatedStickerToSetViaFile(
  long UserId,
  string Name,
  string Emojis,
  InputFile Sticker) :
  AddAnimatedStickerToSet<InputFile>(UserId, Name, Emojis, Sticker), IUploadable
{
  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Sticker
    };
  }
}

public abstract record AddVideoStickerToSet<TWebmSticker>(
  long UserId,
  string Name,
  string Emojis,
  TWebmSticker Sticker) : AddStickerToSetBase(UserId, Name, Emojis);

public sealed record AddVideoStickerToSetViaFile(
  long UserId,
  string Name,
  string Emojis,
  InputFile Sticker) :
  AddVideoStickerToSet<InputFile>(UserId, Name, Emojis, Sticker), IUploadable
{
  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Sticker
    };
  }
}
