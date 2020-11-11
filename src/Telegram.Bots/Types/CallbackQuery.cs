// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public abstract record CallbackQuery
  {
    public string Id { get; init; } = null!;

    public User From { get; init; } = null!;

    public string ChatInstance { get; init; } = null!;
  }

  public sealed record MessageCallbackQuery : CallbackQuery
  {
    public Message Message { get; init; } = null!;

    public string Data { get; init; } = null!;
  }

  public sealed record GameCallbackQuery : CallbackQuery
  {
    public Message Message { get; init; } = null!;

    public string ShortName { get; init; } = null!;
  }

  public sealed record InlineMessageCallbackQuery : CallbackQuery
  {
    public string MessageId { get; init; } = null!;

    public string Data { get; init; } = null!;
  }

  public sealed record InlineGameCallbackQuery : CallbackQuery
  {
    public string MessageId { get; init; } = null!;

    public string ShortName { get; init; } = null!;
  }
}
