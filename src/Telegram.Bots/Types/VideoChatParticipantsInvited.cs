// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System.Collections.Generic;

public sealed record VideoChatParticipantsInvited(IReadOnlyList<User>? Users);
