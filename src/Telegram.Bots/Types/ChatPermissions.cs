// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record ChatPermissions
{
  public bool? CanSendMessages { get; init; }

  public bool? CanSendMediaMessages { get; init; }

  public bool? CanSendPolls { get; init; }

  public bool? CanSendOtherMessages { get; init; }

  public bool? CanAddWebPagePreviews { get; init; }

  public bool? CanChangeInfo { get; init; }

  public bool? CanInviteUsers { get; init; }

  public bool? CanPinMessages { get; init; }

  public bool? CanManageTopics { get; init; }
}
