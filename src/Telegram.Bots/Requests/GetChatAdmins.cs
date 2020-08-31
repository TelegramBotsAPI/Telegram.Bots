// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class GetChatAdmins<TChatId> : IRequest<IReadOnlyList<PrivilegedMember>>,
    IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "getChatAdministrators";

    protected GetChatAdmins(TChatId chatId) => ChatId = chatId;
  }

  public sealed class GetChatAdmins : GetChatAdmins<long>
  {
    public GetChatAdmins(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed class GetChatAdmins : GetChatAdmins<string>
    {
      public GetChatAdmins(string username) : base(username) { }
    }
  }
}
