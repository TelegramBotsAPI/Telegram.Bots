// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed record OrderInfo
  {
    public string? Name { get; init; }

    public string? PhoneNumber { get; init; }

    public string? Email { get; init; }

    public ShippingAddress? ShippingAddress { get; init; }
  }
}
