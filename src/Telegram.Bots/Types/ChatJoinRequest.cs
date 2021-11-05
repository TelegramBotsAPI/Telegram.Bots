// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed record ChatJoinRequest
  {
    public Chat Chat { get; init; } = null!;

    public User From { get; init; } = null!;
    
    public DateTime Date { get; init; } = DateTime.UnixEpoch;
    
    public string? Bio { get; init; }
    
    public ChatInviteLink? InviteLink { get; init; }
  }
}
