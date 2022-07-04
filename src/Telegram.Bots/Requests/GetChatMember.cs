// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record GetChatMember<TChatId>(
    TChatId ChatId, long UserId) : IRequest<ChatMember>,
    IChatMemberTargetable<TChatId>
  {
    public string Method => "getChatMember";
  }

  public sealed record GetChatMember(
    long ChatId,
    long UserId) : GetChatMember<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record GetChatMember(
      string ChatId,
      long UserId) : GetChatMember<string>(ChatId, UserId);
  }
}
