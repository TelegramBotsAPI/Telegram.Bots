// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Webhooks;

using System;
using System.Collections.Generic;

public sealed record WebhookInfo
{
  public Uri? Url { get; init; }

  public bool HasCustomCertificate { get; init; }

  public uint PendingUpdateCount { get; init; }

  public string? IpAddress { get; init; }

  public DateTime? LastErrorDate { get; init; }

  public string? LastErrorMessage { get; init; }

  public DateTime? LastSynchronizationErrorDate { get; init; }

  public uint? MaxConnections { get; init; }

  public IReadOnlyList<UpdateType>? AllowedUpdates { get; init; }
}
