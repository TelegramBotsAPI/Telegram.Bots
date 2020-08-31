// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class PinChatMessage<TChatId> : IRequest<bool>,
    IChatMessageTargetable<TChatId>, INotifiable
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    public bool? DisableNotification { get; set; }

    public string Method { get; } = "pinChatMessage";

    protected PinChatMessage(TChatId chatId, int messageId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed class PinChatMessage : PinChatMessage<long>
  {
    public PinChatMessage(long chatId, int messageId) : base(chatId, messageId) { }
  }

  namespace Usernames
  {
    public sealed class PinChatMessage : PinChatMessage<string>
    {
      public PinChatMessage(string username, int messageId) : base(username, messageId) { }
    }
  }
}
