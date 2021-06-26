// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

namespace Telegram.Bots.Types.Inline
{
  public sealed record InlineQuery
  {
    public string Id { get; init; } = null!;

    public User From { get; init; } = null!;

    public string Query { get; init; } = null!;

    public string Offset { get; init; } = null!;

    public ChatType? ChatType { get; init; }

    public Location? Location { get; init; }
  }
}
