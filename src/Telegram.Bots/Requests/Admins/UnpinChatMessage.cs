// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class UnpinChatMessage<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; set; }

    public string Method { get; } = "unpinChatMessage";

    protected UnpinChatMessage(TChatId chatId) => ChatId = chatId;
  }

  public sealed class UnpinChatMessage : UnpinChatMessage<long>
  {
    public UnpinChatMessage(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed class UnpinChatMessage : UnpinChatMessage<string>
    {
      public UnpinChatMessage(string username) : base(username) { }
    }
  }
}
