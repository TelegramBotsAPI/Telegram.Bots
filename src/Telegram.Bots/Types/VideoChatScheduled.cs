// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed class VideoChatScheduled
  {
    public DateTime StartDate { get; init; } = DateTime.UnixEpoch;
  }
}
