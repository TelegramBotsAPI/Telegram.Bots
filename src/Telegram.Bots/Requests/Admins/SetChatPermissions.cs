// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract class SetChatPermissions<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public ChatPermissions Permissions { get; }

    public string Method { get; } = "SetChatPermissions";

    protected SetChatPermissions(TChatId chatId, ChatPermissions permissions)
    {
      ChatId = chatId;
      Permissions = permissions;
    }
  }

  public sealed class SetChatPermissions : SetChatPermissions<long>
  {
    public SetChatPermissions(long chatId, ChatPermissions permissions) :
      base(chatId, permissions) { }
  }

  namespace Usernames
  {
    public sealed class SetChatPermissions : SetChatPermissions<string>
    {
      public SetChatPermissions(string username, ChatPermissions permissions) :
        base(username, permissions) { }
    }
  }
}
