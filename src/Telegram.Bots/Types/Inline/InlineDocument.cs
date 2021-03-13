// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Telegram.Bots.Types.Inline
{
  public abstract record InlineDocument<TDocument> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Document;

    public string Title { get; }

    public TDocument Document { get; }

    public string? Description { get; init; }

    public string? Caption { get; init; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; init; }

    protected InlineDocument(string id, string title, TDocument document) : base(id)
    {
      Title = title;
      Document = document;
    }
  }

  public sealed record InlineDocument : InlineDocument<Uri>, IThumbable
  {
    public DocumentMimeType MimeType { get; }

    public Uri? Thumb { get; init; }

    public int? ThumbWidth { get; init; }

    public int? ThumbHeight { get; init; }

    public InlineDocument(string id, string title, Uri document, DocumentMimeType mimeType) :
      base(id, title, document) => MimeType = mimeType;
  }

  public sealed record InlineCachedDocument : InlineDocument<string>
  {
    public InlineCachedDocument(string id, string title, string document) :
      base(id, title, document) { }
  }

  public enum DocumentMimeType
  {
    [EnumMember(Value = "application/pdf")]
    Pdf,

    [EnumMember(Value = "application/zip")]
    Zip
  }
}
