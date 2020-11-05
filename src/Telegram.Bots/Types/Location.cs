// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Location
  {
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double? HorizontalAccuracy { get; set; }

    public int? LivePeriod { get; set; }

    public uint? Heading { get; set; }

    public uint? ProximityAlertRadius { get; set; }
  }
}
