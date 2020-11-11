// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract record RestrictChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public ChatPermissions Permissions { get; }

    public DateTime? UntilDate { get; init; }

    public string Method { get; } = "restrictChatMember";

    protected RestrictChatMember(TChatId chatId, int userId, ChatPermissions permissions)
    {
      ChatId = chatId;
      UserId = userId;
      Permissions = permissions;
    }
  }

  public sealed record RestrictChatMember : RestrictChatMember<long>
  {
    public RestrictChatMember(long chatId, int userId, ChatPermissions permissions) :
      base(chatId, userId, permissions) { }
  }

  namespace Usernames
  {
    public sealed record RestrictChatMember : RestrictChatMember<string>
    {
      public RestrictChatMember(string username, int userId, ChatPermissions permissions) :
        base(username, userId, permissions) { }
    }
  }
}
