// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class EditMediaBase<TMedia, TResult> : IRequest<TResult>, IInlineMarkupable
  {
    public InputMedia<TMedia> Media { get; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "editMessageMedia";

    protected EditMediaBase(InputMedia<TMedia> media) => Media = media;
  }

  public abstract class EditMedia<TChatId, TMedia> : EditMediaBase<TMedia, MediaMessage>,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected EditMedia(TChatId chatId, int messageId, InputMedia<TMedia> media) : base(media)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class EditMediaViaCache : EditMedia<long, string>
  {
    public EditMediaViaCache(long chatId, int messageId, InputMedia<string> media) :
      base(chatId, messageId, media) { }
  }

  public sealed class EditMediaViaUrl : EditMedia<long, Uri>
  {
    public EditMediaViaUrl(long chatId, int messageId, InputMedia<Uri> media) :
      base(chatId, messageId, media) { }
  }

  public sealed class EditMediaViaFile : EditMedia<long, InputFile>
  {
    public EditMediaViaFile(long chatId, int messageId, InputMedia<InputFile> media) :
      base(chatId, messageId, media) { }
  }

  namespace Usernames
  {
    public sealed class EditMediaViaCache : EditMedia<string, string>
    {
      public EditMediaViaCache(string username, int messageId, InputMedia<string> media) :
        base(username, messageId, media) { }
    }

    public sealed class EditMediaViaUrl : EditMedia<string, Uri>
    {
      public EditMediaViaUrl(string username, int messageId, InputMedia<Uri> media) :
        base(username, messageId, media) { }
    }

    public sealed class EditMediaViaFile : EditMedia<string, InputFile>
    {
      public EditMediaViaFile(string username, int messageId, InputMedia<InputFile> media) :
        base(username, messageId, media) { }
    }
  }

  namespace Inline
  {
    public abstract class EditMedia<TMedia> : EditMediaBase<TMedia, bool>,
      IInlineMessageTargetable
    {
      public string MessageId { get; }

      protected EditMedia(string messageId, InputMedia<TMedia> media) : base(media) =>
        MessageId = messageId;
    }

    public sealed class EditMediaViaCache : EditMedia<string>
    {
      public EditMediaViaCache(string messageId, InputMedia<string> media) :
        base(messageId, media) { }
    }

    public sealed class EditMediaViaUrl : EditMedia<Uri>
    {
      public EditMediaViaUrl(string messageId, InputMedia<Uri> media) : base(messageId, media) { }
    }
  }
}
