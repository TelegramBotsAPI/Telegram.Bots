// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Extensions.Polling.Configs
{
  public sealed class PollingConfig
  {
    public int Limit { get; }

    public int Timeout { get; }

    public IEnumerable<UpdateType>? AllowedUpdates { get; }

    public PollingConfig(
      int limit = 100,
      int timeout = 60,
      IEnumerable<UpdateType>? allowedUpdates = default)
    {
      Limit = limit;
      Timeout = timeout;
      AllowedUpdates = allowedUpdates;
    }
  }
}
