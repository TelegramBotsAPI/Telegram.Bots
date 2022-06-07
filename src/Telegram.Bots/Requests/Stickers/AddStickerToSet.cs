// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract record AddStickerToSetBase : IRequest<bool>, IUserTargetable
  {
    public long UserId { get; }

    public string Name { get; }

    public string Emojis { get; }

    public MaskPosition? MaskPosition { get; init; }

    public string Method { get; } = "addStickerToSet";

    protected AddStickerToSetBase(long userId, string name, string emojis)
    {
      UserId = userId;
      Name = name;
      Emojis = emojis;
    }
  }

  public abstract record AddStickerToSet<TPngSticker> : AddStickerToSetBase
  {
    public TPngSticker Sticker { get; }

    protected AddStickerToSet(long userId, string name, string emojis, TPngSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed record AddStickerToSetViaCache : AddStickerToSet<string>
  {
    public AddStickerToSetViaCache(long userId, string name, string emojis, string sticker) :
      base(userId, name, emojis, sticker) { }
  }

  public sealed record AddStickerToSetViaUrl : AddStickerToSet<Uri>
  {
    public AddStickerToSetViaUrl(long userId, string name, string emojis, Uri sticker) :
      base(userId, name, emojis, sticker) { }
  }

  public sealed record AddStickerToSetViaFile : AddStickerToSet<InputFile>, IUploadable
  {
    public AddStickerToSetViaFile(long userId, string name, string emojis, InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Sticker};
  }

  public abstract record AddAnimatedStickerToSet<TTgsSticker> : AddStickerToSetBase
  {
    public TTgsSticker Sticker { get; }

    protected AddAnimatedStickerToSet(
      long userId,
      string name,
      string emojis,
      TTgsSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed record AddAnimatedStickerToSetViaFile : AddAnimatedStickerToSet<InputFile>,
    IUploadable
  {
    public AddAnimatedStickerToSetViaFile(
      long userId,
      string name,
      string emojis,
      InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Sticker};
  }
  
  public abstract record AddVideoStickerToSet<TWebmSticker> : AddStickerToSetBase
  {
    public TWebmSticker Sticker { get; }

    protected AddVideoStickerToSet(
      long userId,
      string name,
      string emojis,
      TWebmSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed record AddVideoStickerToSetViaFile : AddVideoStickerToSet<InputFile>,
    IUploadable
  {
    public AddVideoStickerToSetViaFile(
      long userId,
      string name,
      string emojis,
      InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Sticker};
  }
}
