// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract record LeaveChat<TChatId>(
    TChatId ChatId) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "leaveChat";
  }

  public sealed record LeaveChat(long ChatId) : LeaveChat<long>(ChatId);

  namespace Usernames
  {
    public sealed record LeaveChat(string ChatId) : LeaveChat<string>(ChatId);
  }
}
