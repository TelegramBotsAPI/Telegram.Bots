// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed record VideoChatParticipantsInvited
  {
    public IReadOnlyList<User>? Users { get; init; }
  }
}
