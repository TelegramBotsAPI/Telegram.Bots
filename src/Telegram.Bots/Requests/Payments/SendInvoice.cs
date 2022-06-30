// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Payments;

using System;
using System.Collections.Generic;
using Types;
using Types.Payments;

public sealed record SendInvoice(long ChatId,
  string Title,
  string Description,
  string Payload,
  string ProviderToken,
  string Currency,
  IEnumerable<LabeledPrice> Prices) : IRequest<InvoiceMessage>,
  IChatTargetable<long>, IProtectable
{
  public int? MaxTipAmount { get; init; }

  public IEnumerable<int>? SuggestedTipAmounts { get; init; }

  public string? StartParameter { get; init; }

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

  public bool? ProtectContent { get; init; }

  public int? ReplyToMessageId { get; init; }

  public InlineKeyboardMarkup? ReplyMarkup { get; init; }

  public string Method => "sendInvoice";
}
