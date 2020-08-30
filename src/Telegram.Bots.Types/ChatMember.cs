// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  using Status = ChatMemberStatus;

  public abstract class ChatMember
  {
    public User User { get; set; } = null!;

    public abstract Status Status { get; }
  }

  public abstract class PrivilegedMember : ChatMember
  {
    public string? CustomTitle { get; set; }
  }

  public sealed class Creator : PrivilegedMember
  {
    public override Status Status { get; } = Status.Creator;
  }

  public sealed class Administrator : PrivilegedMember
  {
    public override Status Status { get; } = Status.Administrator;

    public bool CanBeEdited { get; set; }

    public bool? CanPostMessages { get; set; }

    public bool? CanEditMessages { get; set; }

    public bool CanDeleteMessages { get; set; }

    public bool CanRestrictMembers { get; set; }

    public bool CanPromoteMembers { get; set; }

    public bool CanChangeInfo { get; set; }

    public bool CanInviteUsers { get; set; }

    public bool? CanPinMessages { get; set; }
  }

  public sealed class NormalMember : ChatMember
  {
    public override Status Status { get; } = Status.Member;
  }

  public sealed class RestrictedMember : ChatMember
  {
    public override Status Status { get; } = Status.Restricted;

    public DateTime UntilDate { get; set; }

    public bool CanChangeInfo { get; set; }

    public bool CanInviteUsers { get; set; }

    public bool? CanPinMessages { get; set; }

    public bool IsMember { get; set; }

    public bool CanSendMessages { get; set; }

    public bool CanSendMediaMessages { get; set; }

    public bool CanSendPolls { get; set; }

    public bool CanSendOtherMessages { get; set; }

    public bool CanAddWebPagePreviews { get; set; }
  }

  public sealed class KickedMember : ChatMember
  {
    public override Status Status { get; } = Status.Kicked;

    public DateTime UntilDate { get; set; }
  }

  public sealed class LeftMember : ChatMember
  {
    public override Status Status { get; } = Status.Left;
  }
}
