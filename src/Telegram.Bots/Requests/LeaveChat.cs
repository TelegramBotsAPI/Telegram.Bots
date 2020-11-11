// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract record LeaveChat<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "leaveChat";

    protected LeaveChat(TChatId chatId) => ChatId = chatId;
  }

  public sealed record LeaveChat : LeaveChat<long>
  {
    public LeaveChat(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record LeaveChat : LeaveChat<string>
    {
      public LeaveChat(string username) : base(username) { }
    }
  }
}
