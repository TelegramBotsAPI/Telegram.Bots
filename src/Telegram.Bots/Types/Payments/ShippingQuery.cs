// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Payments;

public sealed record ShippingQuery
{
  public string Id { get; init; } = null!;

  public User From { get; init; } = null!;

  public string InvoicePayment { get; init; } = null!;

  public ShippingAddress ShippingAddress { get; init; } = null!;
}
