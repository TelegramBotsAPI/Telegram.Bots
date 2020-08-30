// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class KickChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public long? UntilDate { get; set; }

    public string Method { get; } = "kickChatMember";

    protected KickChatMember(TChatId chatId, int userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed class KickChatMember : KickChatMember<long>
  {
    public KickChatMember(long chatId, int userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed class KickChatMember : KickChatMember<string>
    {
      public KickChatMember(string username, int userId) : base(username, userId) { }
    }
  }
}
