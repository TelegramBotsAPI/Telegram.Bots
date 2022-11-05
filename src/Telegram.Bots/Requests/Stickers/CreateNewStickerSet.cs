// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers;

using System;
using System.Collections.Generic;
using Types;
using Types.Stickers;

public abstract record CreateNewStickerSetBase(
  long UserId,
  string Name,
  string Title,
  string Emojis) : IRequest<bool>, IUserTargetable
{
  [System.Obsolete("Use StickerType.")]
  public bool? ContainsMasks { get; init; }

  public StickerType? StickerType { get; init; }

  public MaskPosition? MaskPosition { get; init; }

  public string Method => "createNewStickerSet";
}

public abstract record CreateNewStickerSet<TPngSticker>(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  TPngSticker Sticker) : CreateNewStickerSetBase(UserId, Name, Title, Emojis);

public sealed record CreateNewStickerSetViaCache(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  string Sticker) :
  CreateNewStickerSet<string>(UserId, Name, Title, Emojis, Sticker);

public sealed record CreateNewStickerSetViaUrl(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  Uri Sticker) : CreateNewStickerSet<Uri>(UserId, Name, Title, Emojis, Sticker);

public sealed record CreateNewStickerSetViaFile(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  InputFile Sticker) :
  CreateNewStickerSet<InputFile>(UserId, Name, Title, Emojis, Sticker),
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

public abstract record CreateNewAnimatedStickerSet<TTgsSticker>(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  TTgsSticker Sticker) : CreateNewStickerSetBase(UserId, Name, Title, Emojis);

public sealed record CreateNewAnimatedStickerSetViaFile(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  InputFile Sticker) :
  CreateNewAnimatedStickerSet<InputFile>(UserId, Name, Title, Emojis, Sticker),
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

public abstract record CreateNewVideoStickerSetViaFile<TWebmSticker>(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  TWebmSticker Sticker) : CreateNewStickerSetBase(UserId, Name, Title, Emojis);

public sealed record CreateNewVideoStickerSetViaFile(
  long UserId,
  string Name,
  string Title,
  string Emojis,
  InputFile Sticker) : CreateNewVideoStickerSetViaFile<InputFile>(
    UserId, Name, Title, Emojis, Sticker), IUploadable
{
  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Sticker
    };
  }
}
