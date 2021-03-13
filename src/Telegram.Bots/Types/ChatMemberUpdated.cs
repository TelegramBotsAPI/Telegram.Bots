// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed record ChatMemberUpdated
  {
    public Chat Chat { get; init; }

    public User From { get; init; }

    public DateTime Date { get; init; } = DateTime.UnixEpoch;

    public ChatMember OldChatMember { get; init; }

    public ChatMember NewChatMember { get; init; }

    public ChatInviteLink? InviteLink { get; init; }
  }
}
