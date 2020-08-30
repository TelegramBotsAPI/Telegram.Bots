// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed class ShippingQuery
  {
    public string Id { get; set; } = null!;

    public User From { get; set; } = null!;

    public string InvoicePayment { get; set; } = null!;

    public ShippingAddress ShippingAddress { get; set; } = null!;
  }
}
