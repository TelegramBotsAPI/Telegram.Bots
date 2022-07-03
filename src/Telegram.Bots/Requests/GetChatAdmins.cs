// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System.Collections.Generic;
  using Types;

  public abstract record GetChatAdmins<TChatId>(
    TChatId ChatId) : IRequest<IReadOnlyList<PrivilegedMember>>,
    IChatTargetable<TChatId>
  {
    public string Method => "getChatAdministrators";
  }

  public sealed record GetChatAdmins(long ChatId) : GetChatAdmins<long>(ChatId);

  namespace Usernames
  {
    public sealed record GetChatAdmins(
      string ChatId) : GetChatAdmins<string>(ChatId);
  }
}
