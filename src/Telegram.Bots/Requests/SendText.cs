// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System.Collections.Generic;
  using Types;

  public abstract record SendText<TChatId>(
    TChatId ChatId,
    string Text) : IRequest<TextMessage>, IChatTargetable<TChatId>, INotifiable,
    IProtectable, IReplyable, IMarkupable
  {
    public ParseMode? ParseMode { get; init; }

    public IEnumerable<MessageEntity>? Entities { get; init; }

    public bool? DisableWebPagePreview { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendMessage";
  }

  public sealed record SendText(
    long ChatId,
    string Text) : SendText<long>(ChatId, Text);

  namespace Usernames
  {
    public sealed record SendText(
      string ChatId,
      string Text) : SendText<string>(ChatId, Text);
  }
}
