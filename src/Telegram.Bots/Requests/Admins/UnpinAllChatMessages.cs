// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class UnpinAllChatMessages<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "unpinAllChatMessages";

    protected UnpinAllChatMessages(TChatId chatId) => ChatId = chatId;
  }

  public sealed class UnpinAllChatMessages : UnpinAllChatMessages<long>
  {
    public UnpinAllChatMessages(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed class UnpinAllChatMessages : UnpinAllChatMessages<string>
    {
      public UnpinAllChatMessages(string username) : base(username) { }
    }
  }
}
