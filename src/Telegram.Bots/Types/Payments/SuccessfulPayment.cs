// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Payments
{
  public sealed class SuccessfulPayment
  {
    public string Currency { get; set; } = null!;

    public int TotalAmount { get; set; }

    public string InvoicePayload { get; set; } = null!;

    public string? ShippingOptionId { get; set; }

    public OrderInfo? OrderInfo { get; set; }

    public string TelegramPaymentChargeId { get; set; } = null!;

    public string ProviderPaymentChargeId { get; set; } = null!;
  }
}
