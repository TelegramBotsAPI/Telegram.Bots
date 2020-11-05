// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed class InlineVenue : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Venue;

    public string Title { get; }

    public string Address { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public string? FoursquareId { get; set; }

    public string? FoursquareType { get; set; }

    public string? GooglePlaceId { get; set; }

    public string? GooglePlaceType { get; set; }

    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }

    public InlineVenue(string id, string title, string address, double latitude, double longitude) :
      base(id)
    {
      Title = title;
      Address = address;
      Latitude = latitude;
      Longitude = longitude;
    }
  }
}
