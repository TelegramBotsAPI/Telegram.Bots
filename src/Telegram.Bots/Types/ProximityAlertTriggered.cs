// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record ProximityAlertTriggered
  {
    public User Traveler { get; init; } = null!;

    public User Watcher { get; init; } = null!;

    public int Distance { get; init; }
  }
}
