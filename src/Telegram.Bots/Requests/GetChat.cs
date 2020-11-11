// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record GetChat<TChatId> : IRequest<ChatInfo>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "getChat";

    protected GetChat(TChatId chatId) => ChatId = chatId;
  }

  public sealed record GetChat : GetChat<long>
  {
    public GetChat(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record GetChat : GetChat<string>
    {
      public GetChat(string username) : base(username) { }
    }
  }
}
