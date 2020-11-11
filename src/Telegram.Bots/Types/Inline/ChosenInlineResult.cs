// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Inline
{
  public sealed record ChosenInlineResult
  {
    public string ResultId { get; init; } = null!;

    public User From { get; init; } = null!;

    public string Query { get; init; } = null!;

    public Location? Location { get; init; } = null!;

    public string? MessageId { get; init; }
  }
}
