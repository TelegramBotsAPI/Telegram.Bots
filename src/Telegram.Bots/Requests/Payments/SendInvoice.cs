// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Payments;

namespace Telegram.Bots.Requests.Payments
{
  public sealed record SendInvoice : IRequest<InvoiceMessage>, IChatTargetable<long>
  {
    public long ChatId { get; }

    public string Title { get; }

    public string Description { get; }

    public string Payload { get; }

    public string ProviderToken { get; }

    public string StartParameter { get; }

    public string Currency { get; }

    public IEnumerable<LabeledPrice> Prices { get; }

    public string? ProviderData { get; init; }

    public Uri? Photo { get; init; }

    public int? PhotoSize { get; init; }

    public int? PhotoWidth { get; init; }

    public int? PhotoHeight { get; init; }

    public bool? NeedName { get; init; }

    public bool? NeedPhoneNumber { get; init; }

    public bool? NeedEmail { get; init; }

    public bool? NeedShippingAddress { get; init; }

    public bool? SendPhoneNumberToProvider { get; init; }

    public bool? SendEmailToProvider { get; init; }

    public bool? IsFlexible { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendInvoice";

    public SendInvoice(
      long chatId,
      string title,
      string description,
      string payload,
      string providerToken,
      string startParameter,
      string currency,
      IEnumerable<LabeledPrice> prices)
    {
      ChatId = chatId;
      Title = title;
      Description = description;
      Payload = payload;
      ProviderToken = providerToken;
      StartParameter = startParameter;
      Currency = currency;
      Prices = prices;
    }
  }
}
