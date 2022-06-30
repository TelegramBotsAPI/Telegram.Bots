// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Games;

using Types;

public sealed record SendGame(
  long ChatId,
  string ShortName) : IRequest<GameMessage>, IChatTargetable<long>,
  INotifiable, IProtectable, IReplyable, IInlineMarkupable
{
  public bool? DisableNotification { get; init; }

  public bool? ProtectContent { get; init; }

  public int? ReplyToMessageId { get; init; }

  public bool? AllowSendingWithoutReply { get; init; }

  public InlineKeyboardMarkup? ReplyMarkup { get; init; }

  public string Method => "sendGame";
}
