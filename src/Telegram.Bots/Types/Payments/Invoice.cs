// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed class Invoice
  {
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string StartParameter { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public int TotalAmount { get; set; }
  }
}
