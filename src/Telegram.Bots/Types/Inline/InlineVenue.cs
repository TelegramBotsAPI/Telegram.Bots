// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed record InlineVenue : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Venue;

    public string Title { get; }

    public string Address { get; }

    public double Latitude { get; }

    public double Longitude { get; }

    public string? FoursquareId { get; init; }

    public string? FoursquareType { get; init; }

    public string? GooglePlaceId { get; init; }

    public string? GooglePlaceType { get; init; }

    public Uri? Thumb { get; init; }

    public int? ThumbWidth { get; init; }

    public int? ThumbHeight { get; init; }

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
