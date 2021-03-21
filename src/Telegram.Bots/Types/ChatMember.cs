// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  using Status = ChatMemberStatus;

  public abstract record ChatMember
  {
    public User User { get; init; } = null!;

    public abstract Status Status { get; }
  }

  public abstract record PrivilegedMember : ChatMember
  {
    public string? CustomTitle { get; init; }

    public bool IsAnonymous { get; init; }
  }

  public sealed record Creator : PrivilegedMember
  {
    public override Status Status { get; } = Status.Creator;
  }

  public sealed record Administrator : PrivilegedMember
  {
    public override Status Status { get; } = Status.Administrator;

    public bool CanBeEdited { get; init; }

    public bool CanManageChat { get; init; }

    public bool CanPostMessages { get; init; }

    public bool CanEditMessages { get; init; }

    public bool CanDeleteMessages { get; init; }

    public bool CanManageVoiceChats { get; init; }

    public bool CanRestrictMembers { get; init; }

    public bool CanPromoteMembers { get; init; }

    public bool CanChangeInfo { get; init; }

    public bool CanInviteUsers { get; init; }

    public bool CanPinMessages { get; init; }
  }

  public sealed record NormalMember : ChatMember
  {
    public override Status Status { get; } = Status.Member;
  }

  public sealed record RestrictedMember : ChatMember
  {
    public override Status Status { get; } = Status.Restricted;

    public DateTime UntilDate { get; init; }

    public bool CanChangeInfo { get; init; }

    public bool CanInviteUsers { get; init; }

    public bool CanPinMessages { get; init; }

    public bool IsMember { get; init; }

    public bool CanSendMessages { get; init; }

    public bool CanSendMediaMessages { get; init; }

    public bool CanSendPolls { get; init; }

    public bool CanSendOtherMessages { get; init; }

    public bool CanAddWebPagePreviews { get; init; }
  }

  public sealed record KickedMember : ChatMember
  {
    public override Status Status { get; } = Status.Kicked;

    public DateTime UntilDate { get; init; }
  }

  public sealed record LeftMember : ChatMember
  {
    public override Status Status { get; } = Status.Left;
  }
}
