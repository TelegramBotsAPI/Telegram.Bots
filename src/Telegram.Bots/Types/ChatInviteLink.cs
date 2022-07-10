// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;

public sealed record ChatInviteLink
{
  public string InviteLink { get; init; } = null!;

  public User Creator { get; init; } = null!;

  public bool CreatesJoinRequest { get; init; }

  public bool IsPrimary { get; init; }

  public bool IsRevoked { get; init; }

  public string? Name { get; init; }

  public DateTime? ExpireDate { get; init; }

  public int? MemberLimit { get; init; }

  public int? PendingJoinRequestCount { get; init; }
}
