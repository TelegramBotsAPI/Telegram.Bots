// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendText<TChatId> : IRequest<TextMessage>, IChatTargetable<TChatId>,
    INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public string Text { get; }

    public ParseMode? ParseMode { get; set; }

    public IEnumerable<MessageEntity>? Entities { get; set; }

    public bool? DisableWebPagePreview { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendMessage";

    protected SendText(TChatId chatId, string text)
    {
      ChatId = chatId;
      Text = text;
    }
  }

  public sealed class SendText : SendText<long>
  {
    public SendText(long chatId, string text) : base(chatId, text) { }
  }

  namespace Usernames
  {
    public sealed class SendText : SendText<string>
    {
      public SendText(string username, string text) : base(username, text) { }
    }
  }
}
