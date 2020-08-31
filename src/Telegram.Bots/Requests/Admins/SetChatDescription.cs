// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class SetChatDescription<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Description { get; }

    public string Method { get; } = "setChatDescription";

    protected SetChatDescription(TChatId chatId, string description)
    {
      ChatId = chatId;
      Description = description;
    }
  }

  public sealed class SetChatDescription : SetChatDescription<long>
  {
    public SetChatDescription(long chatId, string description) : base(chatId, description) { }
  }

  namespace Usernames
  {
    public sealed class SetChatDescription : SetChatDescription<string>
    {
      public SetChatDescription(string username, string description) :
        base(username, description) { }
    }
  }
}
