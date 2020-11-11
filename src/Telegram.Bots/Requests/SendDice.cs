// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendDice<TChatId> : IRequest<DiceMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public Emoji Emoji { get; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendDice";

    protected SendDice(TChatId chatId, Emoji emoji = Emoji.Dice)
    {
      ChatId = chatId;
      Emoji = emoji;
    }
  }

  public sealed record SendDice : SendDice<long>
  {
    public SendDice(long chatId, Emoji emoji = Emoji.Dice) : base(chatId, emoji) { }
  }

  namespace Usernames
  {
    public sealed record SendDice : SendDice<string>
    {
      public SendDice(string username, Emoji emoji = Emoji.Dice) : base(username, emoji) { }
    }
  }
}
