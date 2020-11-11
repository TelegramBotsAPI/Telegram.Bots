// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record UnpinChatMessage<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; init; }

    public string Method { get; } = "unpinChatMessage";

    protected UnpinChatMessage(TChatId chatId) => ChatId = chatId;
  }

  public sealed record UnpinChatMessage : UnpinChatMessage<long>
  {
    public UnpinChatMessage(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed record UnpinChatMessage : UnpinChatMessage<string>
    {
      public UnpinChatMessage(string username) : base(username) { }
    }
  }
}
