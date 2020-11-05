// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class ProximityAlertTriggered
  {
    public User Traveler { get; set; } = null!;

    public User Watcher { get; set; } = null!;

    public int Distance { get; set; }
  }
}
