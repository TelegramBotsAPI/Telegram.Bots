// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed record ChatInviteLink
  {
    public string InviteLink { get; init; } = null!;

    public User Creator { get; init; } = null!;
    
    public bool CreatesJoinRequest { get; init; }

    public bool IsPrimary { get; init; }

    public bool IsRevoked { get; init; }

    public DateTime? ExpireDate { get; init; }

    public int? MemberLimit { get; init; }
    
    public int? PendingJoinRequestCount { get; init; }
  }
}
