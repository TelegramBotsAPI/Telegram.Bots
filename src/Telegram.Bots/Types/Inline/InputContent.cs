// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using Payments;
using System.Collections.Generic;

public abstract record InputContent;

public sealed record ContactContent : InputContent
{
  public string PhoneNumber { get; }

  public string FirstName { get; }

  public string? LastName { get; init; }

  public string? Vcard { get; init; }

  public ContactContent(string phoneNumber, string firstName)
  {
    PhoneNumber = phoneNumber;
    FirstName = firstName;
  }
}

public sealed record LocationContent : InputContent
{
  public double Latitude { get; }

  public double Longitude { get; }

  public double? HorizontalAccuracy { get; init; }

  public int? LivePeriod { get; init; }

  public uint? Heading { get; init; }

  public uint? ProximityAlertRadius { get; init; }

  public LocationContent(double latitude, double longitude)
  {
    Latitude = latitude;
    Longitude = longitude;
  }
}

public sealed record TextContent : InputContent
{
  public string Text { get; }

  public ParseMode? ParseMode { get; init; }

  public IEnumerable<MessageEntity>? Entities { get; init; }

  public bool? DisableWebPagePreview { get; init; }

  public TextContent(string text)
  {
    Text = text;
  }
}

public sealed record VenueContent : InputContent
{
  public string Title { get; }

  public string Address { get; }

  public double Latitude { get; }

  public double Longitude { get; }

  public string? FoursquareId { get; init; }

  public string? FoursquareType { get; init; }

  public string? GooglePlaceId { get; init; }

  public string? GooglePlaceType { get; init; }

  public VenueContent(
    string title,
    string address,
    double latitude,
    double longitude)
  {
    Title = title;
    Address = address;
    Latitude = latitude;
    Longitude = longitude;
  }
}

public sealed record InvoiceContent : InputContent
{
  public string Title { get; }

  public string Description { get; }

  public string Payload { get; }

  public string ProviderToken { get; }

  public string Currency { get; }

  public IEnumerable<LabeledPrice> Prices { get; }

  public int? MaxTipAmount { get; init; }

  public IEnumerable<int>? SuggestedTipAmounts { get; init; }

  public string? ProviderData { get; init; }

  public string? PhotoUrl { get; init; }

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

  public InvoiceContent(
    string title,
    string description,
    string payload,
    string providerToken,
    string currency,
    IEnumerable<LabeledPrice> prices)
  {
    Title = title;
    Description = description;
    Payload = payload;
    ProviderToken = providerToken;
    Currency = currency;
    Prices = prices;
  }
}
