// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Payments;

public sealed record Invoice
{
  public string Title { get; init; } = null!;

  public string Description { get; init; } = null!;

  public string StartParameter { get; init; } = null!;

  public string Currency { get; init; } = null!;

  public int TotalAmount { get; init; }
}
