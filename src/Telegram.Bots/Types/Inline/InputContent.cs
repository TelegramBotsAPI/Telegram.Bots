// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Inline
{
  public abstract class InputContent { }

  public sealed class ContactContent : InputContent
  {
    public string PhoneNumber { get; }

    public string FirstName { get; }

    public string? LastName { get; set; }

    public string? Vcard { get; set; }

    public ContactContent(string phoneNumber, string firstName)
    {
      PhoneNumber = phoneNumber;
      FirstName = firstName;
    }
  }

  public sealed class LocationContent : InputContent
  {
    public double Latitude { get; }

    public double Longitude { get; }

    public int? LivePeriod { get; set; }

    public uint? Heading { get; set; }

    public uint? ProximityAlertRadius { get; set; }

    public LocationContent(double latitude, double longitude)
    {
      Latitude = latitude;
      Longitude = longitude;
    }
  }

  public sealed class TextContent : InputContent
  {
    public string Text { get; }

    public ParseMode? ParseMode { get; set; }

    public bool? DisableWebPagePreview { get; set; }

    public TextContent(string text) => Text = text;
  }

  public sealed class VenueContent : InputContent
  {
    public string Title { get; }

    public string Address { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public string? FoursquareId { get; set; }

    public string? FoursquareType { get; set; }

    public VenueContent(string title, string address, double latitude, double longitude)
    {
      Title = title;
      Address = address;
      Latitude = latitude;
      Longitude = longitude;
    }
  }
}
