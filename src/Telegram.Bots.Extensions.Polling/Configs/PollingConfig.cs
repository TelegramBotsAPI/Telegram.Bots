// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Extensions.Polling.Configs
{
  public sealed class PollingConfig
  {
    public int Limit { get; set; } = 100;

    public int Timeout { get; set; } = 60;

    public IEnumerable<UpdateType>? AllowedUpdates { get; set; }
  }
}
