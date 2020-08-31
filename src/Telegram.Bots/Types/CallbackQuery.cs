// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public abstract class CallbackQuery
  {
    public string Id { get; set; } = null!;

    public User From { get; set; } = null!;

    public string ChatInstance { get; set; } = null!;
  }

  public sealed class MessageCallbackQuery : CallbackQuery
  {
    public Message Message { get; set; } = null!;

    public string Data { get; set; } = null!;
  }

  public sealed class GameCallbackQuery : CallbackQuery
  {
    public Message Message { get; set; } = null!;

    public string ShortName { get; set; } = null!;
  }

  public sealed class InlineMessageCallbackQuery : CallbackQuery
  {
    public string MessageId { get; set; } = null!;

    public string Data { get; set; } = null!;
  }

  public sealed class InlineGameCallbackQuery : CallbackQuery
  {
    public string MessageId { get; set; } = null!;

    public string ShortName { get; set; } = null!;
  }
}
