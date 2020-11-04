// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class UnbanChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public bool? OnlyIfBanned { get; set; }

    public string Method { get; } = "unbanChatMember";

    protected UnbanChatMember(TChatId chatId, int userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed class UnbanChatMember : UnbanChatMember<long>
  {
    public UnbanChatMember(long chatId, int userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed class UnbanChatMember : UnbanChatMember<string>
    {
      public UnbanChatMember(string username, int userId) : base(username, userId) { }
    }
  }
}
