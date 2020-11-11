// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed record ShippingAddress
  {
    public string CountryCode { get; init; } = null!;

    public string State { get; init; } = null!;

    public string City { get; init; } = null!;

    public string StreetLine1 { get; init; } = null!;

    public string StreetLine2 { get; init; } = null!;

    public string PostCode { get; init; } = null!;
  }
}
