// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using Telegram.Bots.Types.Inline;
using Telegram.Bots.Types.Payments;

namespace Telegram.Bots.Types
{
  public abstract record Update
  {
    public int Id { get; init; }
  }

  public sealed record MessageUpdate : Update
  {
    public Message Data { get; init; } = null!;
  }

  public sealed record EditedMessageUpdate : Update
  {
    public Message Data { get; init; } = null!;
  }

  public sealed record ChannelPostUpdate : Update
  {
    public Message Data { get; init; } = null!;
  }

  public sealed record EditedChannelPostUpdate : Update
  {
    public Message Data { get; init; } = null!;
  }

  public sealed record InlineQueryUpdate : Update
  {
    public InlineQuery Data { get; init; } = null!;
  }

  public sealed record ChosenInlineResultUpdate : Update
  {
    public ChosenInlineResult Data { get; init; } = null!;
  }

  public sealed record CallbackQueryUpdate : Update
  {
    public CallbackQuery Data { get; init; } = null!;
  }

  public sealed record ShippingQueryUpdate : Update
  {
    public ShippingQuery Data { get; init; } = null!;
  }

  public sealed record PreCheckoutQueryUpdate : Update
  {
    public PreCheckoutQuery Data { get; init; } = null!;
  }

  public sealed record PollUpdate : Update
  {
    public Poll Data { get; init; } = null!;
  }

  public sealed record PollAnswerUpdate : Update
  {
    public PollAnswer Data { get; init; } = null!;
  }

  public sealed record MyChatMemberUpdate : Update
  {
    public ChatMemberUpdated Data { get; init; } = null!;
  }

  public sealed record ChatMemberUpdate : Update
  {
    public ChatMemberUpdated Data { get; init; } = null!;
  }
  
  public sealed record ChatJoinRequestUpdate : Update
  {
    public ChatJoinRequest Data { get; init; } = null!;
  }
}
