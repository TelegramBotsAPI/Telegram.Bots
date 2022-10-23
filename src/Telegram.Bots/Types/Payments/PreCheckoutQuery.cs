// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Payments;

public sealed record PreCheckoutQuery
{
  public string Id { get; init; } = null!;

  public User From { get; init; } = null!;

  public string Currency { get; init; } = null!;

  public int TotalAmount { get; init; }

  public string InvoicePayload { get; init; } = null!;

  public string? ShippingOptionId { get; init; }

  public OrderInfo? OrderInfo { get; init; }
}
