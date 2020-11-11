// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Webhooks
{
  public sealed record WebhookInfo
  {
    public Uri? Url { get; init; }

    public bool HasCustomCertificate { get; init; }

    public uint PendingUpdateCount { get; init; }

    public string? IpAddress { get; init; }

    public DateTime? LastErrorDate { get; init; }

    public string? LastErrorMessage { get; init; }

    public uint? MaxConnections { get; init; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
  }
}
