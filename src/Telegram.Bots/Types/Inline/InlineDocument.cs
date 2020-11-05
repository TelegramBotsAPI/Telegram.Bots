// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Telegram.Bots.Types.Inline
{
  public abstract class InlineDocument<TDocument> : ReplaceableResult, ICaptionable
  {
    public override ResultType Type { get; } = ResultType.Document;

    public string Title { get; }

    public TDocument Document { get; }

    public string? Description { get; set; }

    public string? Caption { get; set; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? CaptionEntities { get; set; }

    protected InlineDocument(string id, string title, TDocument document) : base(id)
    {
      Title = title;
      Document = document;
    }
  }

  public sealed class InlineDocument : InlineDocument<Uri>, IThumbable
  {
    public DocumentMimeType MimeType { get; }

    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }

    public InlineDocument(string id, string title, Uri document, DocumentMimeType mimeType) :
      base(id, title, document) => MimeType = mimeType;
  }

  public sealed class InlineCachedDocument : InlineDocument<string>
  {
    public InlineCachedDocument(string id, string title, string document) :
      base(id, title, document) { }
  }

  public enum DocumentMimeType
  {
    [EnumMember(Value = "application/pdf")] Pdf,
    [EnumMember(Value = "application/zip")] Zip
  }
}
