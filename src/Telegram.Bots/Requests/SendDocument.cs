// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendDocument<TChatId, TDocument> : IRequest<DocumentMessage>,
    IChatTargetable<TChatId>, ICaptionable, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public TDocument Document { get; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendDocument";

    protected SendDocument(TChatId chatId, TDocument document)
    {
      ChatId = chatId;
      Document = document;
    }
  }

  public abstract class SendDocumentFile<TChatId> : SendDocument<TChatId, InputFile>, IUploadable
  {
    public InputFile? Thumb { get; set; }

    public bool? DisableContentTypeDetection { get; set; }

    protected SendDocumentFile(TChatId chatId, InputFile document) : base(chatId, document) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Document, Thumb };
  }

  public sealed class SendCachedDocument : SendDocument<long, string>
  {
    public SendCachedDocument(long chatId, string document) : base(chatId, document) { }
  }

  public sealed class SendDocumentUrl : SendDocument<long, Uri>
  {
    public SendDocumentUrl(long chatId, Uri document) : base(chatId, document) { }
  }

  public sealed class SendDocumentFile : SendDocumentFile<long>
  {
    public SendDocumentFile(long chatId, InputFile document) : base(chatId, document) { }
  }

  namespace Usernames
  {
    public sealed class SendCachedDocument : SendDocument<string, string>
    {
      public SendCachedDocument(string username, string document) : base(username, document) { }
    }

    public sealed class SendDocumentUrl : SendDocument<string, Uri>
    {
      public SendDocumentUrl(string username, Uri document) : base(username, document) { }
    }

    public sealed class SendDocumentFile : SendDocumentFile<string>
    {
      public SendDocumentFile(string username, InputFile document) : base(username, document) { }
    }
  }
}
