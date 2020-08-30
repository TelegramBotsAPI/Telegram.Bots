// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed class OrderInfo
  {
    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public ShippingAddress? ShippingAddress { get; set; }
  }
}
