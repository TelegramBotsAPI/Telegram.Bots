// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class ChatLocation
  {
    public Location Location { get; set; } = null!;

    public string Address { get; set; } = null!;
  }
}
