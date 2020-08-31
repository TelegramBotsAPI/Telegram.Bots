// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract class AddStickerToSetBase : IRequest<bool>, IUserTargetable
  {
    public int UserId { get; }

    public string Name { get; }

    public string Emojis { get; }

    public MaskPosition? MaskPosition { get; set; }

    public string Method { get; } = "addStickerToSet";

    protected AddStickerToSetBase(int userId, string name, string emojis)
    {
      UserId = userId;
      Name = name;
      Emojis = emojis;
    }
  }

  public abstract class AddStickerToSet<TPngSticker> : AddStickerToSetBase
  {
    public TPngSticker Sticker { get; }

    protected AddStickerToSet(int userId, string name, string emojis, TPngSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed class AddStickerToSetViaCache : AddStickerToSet<string>
  {
    public AddStickerToSetViaCache(int userId, string name, string emojis, string sticker) :
      base(userId, name, emojis, sticker) { }
  }

  public sealed class AddStickerToSetViaUrl : AddStickerToSet<Uri>
  {
    public AddStickerToSetViaUrl(int userId, string name, string emojis, Uri sticker) :
      base(userId, name, emojis, sticker) { }
  }

  public sealed class AddStickerToSetViaFile : AddStickerToSet<InputFile>, IUploadable
  {
    public AddStickerToSetViaFile(int userId, string name, string emojis, InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }

  public abstract class AddAnimatedStickerToSet<TTgsSticker> : AddStickerToSetBase
  {
    public TTgsSticker Sticker { get; }

    protected AddAnimatedStickerToSet(int userId, string name, string emojis, TTgsSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed class AddAnimatedStickerToSetViaFile : AddAnimatedStickerToSet<InputFile>,
    IUploadable
  {
    public AddAnimatedStickerToSetViaFile(
      int userId,
      string name,
      string emojis,
      InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }
}
