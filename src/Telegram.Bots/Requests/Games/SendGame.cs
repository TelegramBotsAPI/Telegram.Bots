// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Games
{
  public sealed record SendGame : IRequest<GameMessage>,
    IChatTargetable<long>, INotifiable, IReplyable, IInlineMarkupable
  {
    public long ChatId { get; }

    public string ShortName { get; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendGame";

    public SendGame(long chatId, string shortName)
    {
      ChatId = chatId;
      ShortName = shortName;
    }
  }
}
