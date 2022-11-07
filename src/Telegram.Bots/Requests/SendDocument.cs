// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System;
  using System.Collections.Generic;
  using Types;

  public abstract record SendDocument<TChatId, TDocument>(
    TChatId ChatId,
    TDocument Document) : IRequest<DocumentMessage>, IChatTargetable<TChatId>,
    IThreadable, ICaptionable, INotifiable, IProtectable, IReplyable,
    IMarkupable
  {
    public int? ThreadId { get; init; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendDocument";
  }

  public abstract record SendDocumentFile<TChatId>(
    TChatId ChatId,
    InputFile Document) : SendDocument<TChatId, InputFile>(ChatId, Document),
    IUploadable
  {
    public InputFile? Thumb { get; init; }

    public bool? DisableContentTypeDetection { get; init; }

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Document, Thumb
      };
    }
  }

  public sealed record SendCachedDocument(
    long ChatId,
    string Document) : SendDocument<long, string>(ChatId, Document);

  public sealed record SendDocumentUrl(
    long ChatId,
    Uri Document) : SendDocument<long, Uri>(ChatId, Document);

  public sealed record SendDocumentFile(
    long ChatId,
    InputFile Document) : SendDocumentFile<long>(ChatId, Document);

  namespace Usernames
  {
    public sealed record SendCachedDocument(
      string ChatId,
      string Document) : SendDocument<string, string>(ChatId, Document);

    public sealed record SendDocumentUrl(
      string ChatId,
      Uri Document) : SendDocument<string, Uri>(ChatId, Document);

    public sealed record SendDocumentFile(
      string ChatId,
      InputFile Document) : SendDocumentFile<string>(ChatId, Document);
  }
}
