// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record StopPollBase : IRequest<PollMessage>, IInlineMarkupable
  {
    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method => "stopPoll";
  }

  public abstract record StopPoll<TChatId>(
    TChatId ChatId,
    int MessageId) : StopPollBase, IChatMessageTargetable<TChatId>;

  public sealed record StopPoll(
    long ChatId,
    int MessageId) : StopPoll<long>(ChatId, MessageId);

  namespace Usernames
  {
    public sealed record StopPoll(
      string ChatId,
      int MessageId) : StopPoll<string>(ChatId, MessageId);
  }
}
