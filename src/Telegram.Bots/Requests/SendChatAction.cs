// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendChatAction<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public ChatAction Action { get; }

    public string Method { get; } = "sendChatAction";

    protected SendChatAction(TChatId chatId, ChatAction action)
    {
      ChatId = chatId;
      Action = action;
    }
  }

  public sealed class SendChatAction : SendChatAction<long>
  {
    public SendChatAction(long chatId, ChatAction action) : base(chatId, action) { }
  }

  namespace Usernames
  {
    public sealed class SendChatAction : SendChatAction<string>
    {
      public SendChatAction(string username, ChatAction action) : base(username, action) { }
    }
  }
}
