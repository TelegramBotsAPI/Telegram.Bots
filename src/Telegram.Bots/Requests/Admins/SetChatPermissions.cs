// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  using Types;

  public abstract record SetChatPermissions<TChatId>(
    TChatId ChatId,
    ChatPermissions Permissions) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "SetChatPermissions";
  }

  public sealed record SetChatPermissions(
    long ChatId,
    ChatPermissions Permissions) :
    SetChatPermissions<long>(ChatId, Permissions);

  namespace Usernames
  {
    public sealed record SetChatPermissions(
      string ChatId,
      ChatPermissions Permissions) :
      SetChatPermissions<string>(ChatId, Permissions);
  }
}
