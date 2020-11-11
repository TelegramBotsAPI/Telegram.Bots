// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendPhoto<TChatId, TPhoto> : IRequest<PhotoMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TPhoto Photo { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendPhoto";

    protected SendPhoto(TChatId chatId, TPhoto photo)
    {
      ChatId = chatId;
      Photo = photo;
    }
  }

  public abstract record SendPhotoFile<TChatId> : SendPhoto<TChatId, InputFile>, IUploadable
  {
    protected SendPhotoFile(TChatId chatId, InputFile photo) : base(chatId, photo) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Photo };
  }

  public sealed record SendCachedPhoto : SendPhoto<long, string>
  {
    public SendCachedPhoto(long chatId, string photo) : base(chatId, photo) { }
  }

  public sealed record SendPhotoUrl : SendPhoto<long, Uri>
  {
    public SendPhotoUrl(long chatId, Uri photo) : base(chatId, photo) { }
  }

  public sealed record SendPhotoFile : SendPhotoFile<long>
  {
    public SendPhotoFile(long chatId, InputFile photo) : base(chatId, photo) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedPhoto : SendPhoto<string, string>
    {
      public SendCachedPhoto(string username, string photo) : base(username, photo) { }
    }

    public sealed record SendPhotoUrl : SendPhoto<string, Uri>
    {
      public SendPhotoUrl(string username, Uri photo) : base(username, photo) { }
    }

    public sealed record SendPhotoFile : SendPhotoFile<string>
    {
      public SendPhotoFile(string username, InputFile photo) : base(username, photo) { }
    }
  }
}
