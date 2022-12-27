// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Stickers
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendSticker<TChatId, TSticker>(
    TChatId ChatId,
    TSticker Sticker) : IRequest<StickerMessage>, IChatTargetable<TChatId>,
    IThreadable, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public int? ThreadId { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendSticker";
  }

  public abstract record SendStickerFile<TChatId>(
    TChatId ChatId,
    InputFile Sticker) : SendSticker<TChatId, InputFile>(ChatId, Sticker),
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

  public sealed record SendCachedSticker(
    long ChatId,
    string Sticker) : SendSticker<long, string>(ChatId, Sticker);

  public sealed record SendStickerUrl(
    long ChatId,
    Uri Sticker) : SendSticker<long, Uri>(ChatId, Sticker);

  public sealed record SendStickerFile(
    long ChatId,
    InputFile Sticker) : SendStickerFile<long>(ChatId, Sticker);

  namespace Usernames
  {
    public sealed record SendCachedSticker(
      string ChatId,
      string Sticker) : SendSticker<string, string>(ChatId, Sticker);

    public sealed record SendStickerUrl(
      string ChatId,
      Uri Sticker) : SendSticker<string, Uri>(ChatId, Sticker);

    public sealed record SendStickerFile(
      string ChatId,
      InputFile Sticker) : SendStickerFile<string>(ChatId, Sticker);
  }
}
