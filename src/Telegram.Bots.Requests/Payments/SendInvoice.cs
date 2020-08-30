// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Payments;

namespace Telegram.Bots.Requests.Payments
{
  public sealed class SendInvoice : IRequest<InvoiceMessage>, IChatTargetable<long>
  {
    public long ChatId { get; }

    public string Title { get; }

    public string Description { get; }

    public string Payload { get; }

    public string ProviderToken { get; }

    public string StartParameter { get; }

    public string Currency { get; }

    public IEnumerable<LabeledPrice> Prices { get; }

    public string? ProviderData { get; set; }

    public Uri? Photo { get; set; }

    public int? PhotoSize { get; set; }

    public int? PhotoWidth { get; set; }

    public int? PhotoHeight { get; set; }

    public bool? NeedName { get; set; }

    public bool? NeedPhoneNumber { get; set; }

    public bool? NeedEmail { get; set; }

    public bool? NeedShippingAddress { get; set; }

    public bool? SendPhoneNumberToProvider { get; set; }

    public bool? SendEmailToProvider { get; set; }

    public bool? IsFlexible { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public InlineKeyboardMarkup? ReplyMarkup { get; set; }

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
