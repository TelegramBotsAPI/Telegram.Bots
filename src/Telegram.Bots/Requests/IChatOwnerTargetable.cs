// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

public interface IChatOwnerTargetable<out TChatId> : IChatTargetable<TChatId>
{
  long SenderChatId { get; }
}
