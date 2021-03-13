// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract record SendSticker<TChatId, TSticker> : IRequest<StickerMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TSticker Sticker { get; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendSticker";

    protected SendSticker(TChatId chatId, TSticker sticker)
    {
      ChatId = chatId;
      Sticker = sticker;
    }
  }

  public abstract record SendStickerFile<TChatId> : SendSticker<TChatId, InputFile>, IUploadable
  {
    protected SendStickerFile(TChatId chatId, InputFile sticker) : base(chatId, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Sticker};
  }

  public sealed record SendCachedSticker : SendSticker<long, string>
  {
    public SendCachedSticker(long chatId, string sticker) : base(chatId, sticker) { }
  }

  public sealed record SendStickerUrl : SendSticker<long, Uri>
  {
    public SendStickerUrl(long chatId, Uri sticker) : base(chatId, sticker) { }
  }

  public sealed record SendStickerFile : SendStickerFile<long>
  {
    public SendStickerFile(long chatId, InputFile sticker) : base(chatId, sticker) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedSticker : SendSticker<string, string>
    {
      public SendCachedSticker(string username, string sticker) : base(username, sticker) { }
    }

    public sealed record SendStickerUrl : SendSticker<string, Uri>
    {
      public SendStickerUrl(string username, Uri sticker) : base(username, sticker) { }
    }

    public sealed record SendStickerFile : SendStickerFile<string>
    {
      public SendStickerFile(string username, InputFile sticker) : base(username, sticker) { }
    }
  }
}
