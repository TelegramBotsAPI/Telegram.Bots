// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract record GetChatMemberCount<TChatId>(
    TChatId ChatId) : IRequest<uint>, IChatTargetable<TChatId>
  {
    public string Method => "getChatMemberCount";
  }

  public sealed record GetChatMemberCount(
    long ChatId) : GetChatMemberCount<long>(ChatId);

  namespace Usernames
  {
    public sealed record GetChatMemberCount(
      string ChatId) : GetChatMemberCount<string>(ChatId);
  }
}
