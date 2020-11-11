// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract record CreateNewStickerSetBase : IRequest<bool>, IUserTargetable
  {
    public int UserId { get; }

    public string Name { get; }

    public string Title { get; }

    public string Emojis { get; }

    public bool? ContainsMasks { get; init; }

    public MaskPosition? MaskPosition { get; init; }

    public string Method { get; } = "createNewStickerSet";

    protected CreateNewStickerSetBase(int userId, string name, string title, string emojis)
    {
      UserId = userId;
      Name = name;
      Title = title;
      Emojis = emojis;
    }
  }

  public abstract record CreateNewStickerSet<TPngSticker> : CreateNewStickerSetBase
  {
    public TPngSticker Sticker { get; }

    protected CreateNewStickerSet(
      int userId,
      string name,
      string title,
      string emojis,
      TPngSticker sticker) : base(userId, name, title, emojis) => Sticker = sticker;
  }

  public sealed record CreateNewStickerSetViaCache : CreateNewStickerSet<string>
  {
    public CreateNewStickerSetViaCache(
      int userId,
      string name,
      string title,
      string emojis,
      string sticker) : base(userId, name, title, emojis, sticker) { }
  }

  public sealed record CreateNewStickerSetViaUrl : CreateNewStickerSet<Uri>
  {
    public CreateNewStickerSetViaUrl(
      int userId,
      string name,
      string title,
      string emojis,
      Uri sticker) : base(userId, name, title, emojis, sticker) { }
  }

  public sealed record CreateNewStickerSetViaFile : CreateNewStickerSet<InputFile>, IUploadable
  {
    public CreateNewStickerSetViaFile(
      int userId,
      string name,
      string title,
      string emojis,
      InputFile sticker) : base(userId, name, title, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }

  public abstract record CreateNewAnimatedStickerSet<TTgsSticker> : CreateNewStickerSetBase
  {
    public TTgsSticker Sticker { get; }

    protected CreateNewAnimatedStickerSet(
      int userId,
      string name,
      string title,
      string emojis,
      TTgsSticker sticker) : base(userId, name, title, emojis) => Sticker = sticker;
  }

  public sealed record CreateNewAnimatedStickerSetViaFile : CreateNewAnimatedStickerSet<InputFile>,
    IUploadable
  {
    public CreateNewAnimatedStickerSetViaFile(
      int userId,
      string name,
      string title,
      string emojis,
      InputFile sticker) : base(userId, name, title, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }
}
