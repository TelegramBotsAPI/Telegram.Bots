// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record SendDice<TChatId>(
    TChatId ChatId,
    Emoji Emoji = Emoji.Dice) : IRequest<DiceMessage>, IChatTargetable<TChatId>,
    INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendDice";
  }

  public sealed record SendDice(
    long ChatId,
    Emoji Emoji = Emoji.Dice) : SendDice<long>(ChatId, Emoji);

  namespace Usernames
  {
    public sealed record SendDice(
      string ChatId,
      Emoji Emoji = Emoji.Dice) : SendDice<string>(ChatId, Emoji);
  }
}
