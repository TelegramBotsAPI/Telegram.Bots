// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendDocument<TChatId, TDocument> : IRequest<DocumentMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TDocument Document { get; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendDocument";

    protected SendDocument(TChatId chatId, TDocument document)
    {
      ChatId = chatId;
      Document = document;
    }
  }

  public abstract record SendDocumentFile<TChatId> : SendDocument<TChatId, InputFile>, IUploadable
  {
    public InputFile? Thumb { get; init; }

    public bool? DisableContentTypeDetection { get; init; }

    protected SendDocumentFile(TChatId chatId, InputFile document) : base(chatId, document) { }

    public IEnumerable<InputFile?> GetFiles() => new[] {Document, Thumb};
  }

  public sealed record SendCachedDocument : SendDocument<long, string>
  {
    public SendCachedDocument(long chatId, string document) : base(chatId, document) { }
  }

  public sealed record SendDocumentUrl : SendDocument<long, Uri>
  {
    public SendDocumentUrl(long chatId, Uri document) : base(chatId, document) { }
  }

  public sealed record SendDocumentFile : SendDocumentFile<long>
  {
    public SendDocumentFile(long chatId, InputFile document) : base(chatId, document) { }
  }

  namespace Usernames
  {
    public sealed record SendCachedDocument : SendDocument<string, string>
    {
      public SendCachedDocument(string username, string document) : base(username, document) { }
    }

    public sealed record SendDocumentUrl : SendDocument<string, Uri>
    {
      public SendDocumentUrl(string username, Uri document) : base(username, document) { }
    }

    public sealed record SendDocumentFile : SendDocumentFile<string>
    {
      public SendDocumentFile(string username, InputFile document) : base(username, document) { }
    }
  }
}
