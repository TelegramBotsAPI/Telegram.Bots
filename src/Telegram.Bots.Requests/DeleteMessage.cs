// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  public abstract class DeleteMessage<TChatId> : IRequest<bool>, IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    public string Method { get; } = "deleteMessage";

    protected DeleteMessage(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class DeleteMessage : DeleteMessage<long>
  {
    public DeleteMessage(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class DeleteMessage : DeleteMessage<string>
    {
      public DeleteMessage(string username, int messageId) : base(username, messageId) { }
    }
  }
}
