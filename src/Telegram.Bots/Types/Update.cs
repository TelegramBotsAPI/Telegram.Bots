// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types.Inline;
using Telegram.Bots.Types.Payments;

namespace Telegram.Bots.Types
{
  public abstract class Update
  {
    public int Id { get; set; }
  }

  public sealed class MessageUpdate : Update
  {
    public Message Data { get; set; } = null!;
  }

  public sealed class EditedMessageUpdate : Update
  {
    public Message Data { get; set; } = null!;
  }

  public sealed class ChannelPostUpdate : Update
  {
    public Message Data { get; set; } = null!;
  }

  public sealed class EditedChannelPostUpdate : Update
  {
    public Message Data { get; set; } = null!;
  }

  public sealed class InlineQueryUpdate : Update
  {
    public InlineQuery Data { get; set; } = null!;
  }

  public sealed class ChosenInlineResultUpdate : Update
  {
    public ChosenInlineResult Data { get; set; } = null!;
  }

  public sealed class CallbackQueryUpdate : Update
  {
    public CallbackQuery Data { get; set; } = null!;
  }

  public sealed class ShippingQueryUpdate : Update
  {
    public ShippingQuery Data { get; set; } = null!;
  }

  public sealed class PreCheckoutQueryUpdate : Update
  {
    public PreCheckoutQuery Data { get; set; } = null!;
  }

  public sealed class PollUpdate : Update
  {
    public Poll Data { get; set; } = null!;
  }

  public sealed class PollAnswerUpdate : Update
  {
    public PollAnswer Data { get; set; } = null!;
  }
}
