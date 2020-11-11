// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendText<TChatId> : IRequest<TextMessage>, IChatTargetable<TChatId>,
    INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public string Text { get; }

    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? Entities { get; init; }

    public bool? DisableWebPagePreview { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendMessage";

    protected SendText(TChatId chatId, string text)
    {
      ChatId = chatId;
      Text = text;
    }
  }

  public sealed record SendText : SendText<long>
  {
    public SendText(long chatId, string text) : base(chatId, text) { }
  }

  namespace Usernames
  {
    public sealed record SendText : SendText<string>
    {
      public SendText(string username, string text) : base(username, text) { }
    }
  }
}
