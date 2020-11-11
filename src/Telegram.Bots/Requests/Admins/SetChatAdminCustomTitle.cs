// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record SetChatAdminCustomTitle<TChatId> : IRequest<bool>,
    IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public string CustomTitle { get; }

    public string Method { get; } = "setChatAdministratorCustomTitle";

    protected SetChatAdminCustomTitle(TChatId chatId, int userId, string customTitle)
    {
      ChatId = chatId;
      UserId = userId;
      CustomTitle = customTitle;
    }
  }

  public sealed record SetChatAdminCustomTitle : SetChatAdminCustomTitle<long>
  {
    public SetChatAdminCustomTitle(long chatId, int userId, string customTitle) :
      base(chatId, userId, customTitle) { }
  }

  namespace Usernames
  {
    public sealed record SetChatAdminCustomTitle : SetChatAdminCustomTitle<string>
    {
      public SetChatAdminCustomTitle(string username, int userId, string customTitle) :
        base(username, userId, customTitle) { }
    }
  }
}
