// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed class LabeledPrice
  {
    public string Label { get; set; } = null!;

    public int Amount { get; set; }
  }
}
