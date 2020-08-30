// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class SetChatTitle<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Title { get; }

    public string Method { get; } = "setChatTitle";

    protected SetChatTitle(TChatId chatId, string title)
    {
      ChatId = chatId;
      Title = title;
    }
  }

  public sealed class SetChatTitle : SetChatTitle<long>
  {
    public SetChatTitle(long chatId, string title) : base(chatId, title) { }
  }

  namespace Usernames
  {
    public sealed class SetChatTitle : SetChatTitle<string>
    {
      public SetChatTitle(string username, string title) : base(username, title) { }
    }
  }
}
