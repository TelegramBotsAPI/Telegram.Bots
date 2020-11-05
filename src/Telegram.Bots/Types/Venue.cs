// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Venue
  {
    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public Location Location { get; set; } = null!;

    public string? FoursquareId { get; set; }

    public string? FoursquareType { get; set; }

    public string? GooglePlaceId { get; set; }

    public string? GooglePlaceType { get; set; }
  }
}
