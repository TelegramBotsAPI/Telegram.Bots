// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

public interface IChatMemberTargetable<out TChatId> : IChatTargetable<TChatId>,
  IUserTargetable { }
