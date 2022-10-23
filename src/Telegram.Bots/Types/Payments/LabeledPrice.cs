// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Payments;

public sealed record LabeledPrice
{
  public string Label { get; init; } = null!;

  public int Amount { get; init; }
}
