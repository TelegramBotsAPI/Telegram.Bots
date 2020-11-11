// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record DeleteChatPhoto<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "deleteChatPhoto";

    protected DeleteChatPhoto(TChatId chatId) => ChatId = chatId;
  }

  public sealed record DeleteChatPhoto : DeleteChatPhoto<long>
  {
    public DeleteChatPhoto(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record DeleteChatPhoto : DeleteChatPhoto<string>
    {
      public DeleteChatPhoto(string username) : base(username) { }
    }
  }
}
