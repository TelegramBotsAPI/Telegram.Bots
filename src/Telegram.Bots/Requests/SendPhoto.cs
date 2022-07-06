// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendPhoto<TChatId, TPhoto>(
    TChatId ChatId,
    TPhoto Photo) : IRequest<PhotoMessage>, IChatTargetable<TChatId>,
    ICaptionable, INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendPhoto";
  }

  public abstract record SendPhotoFile<TChatId>(
    TChatId ChatId,
    InputFile Photo) : SendPhoto<TChatId, InputFile>(ChatId, Photo), IUploadable
  {
    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Photo
      };
    }
  }

  public sealed record SendCachedPhoto(
    long ChatId,
    string Photo) : SendPhoto<long, string>(ChatId, Photo);

  public sealed record SendPhotoUrl(
    long ChatId,
    Uri Photo) : SendPhoto<long, Uri>(ChatId, Photo);

  public sealed record SendPhotoFile(
    long ChatId,
    InputFile Photo) : SendPhotoFile<long>(ChatId, Photo);

  namespace Usernames
  {
    public sealed record SendCachedPhoto(
      string ChatId,
      string Photo) : SendPhoto<string, string>(ChatId, Photo);

    public sealed record SendPhotoUrl(
      string ChatId,
      Uri Photo) : SendPhoto<string, Uri>(ChatId, Photo);

    public sealed record SendPhotoFile(
      string ChatId,
      InputFile Photo) : SendPhotoFile<string>(ChatId, Photo);
  }
}
