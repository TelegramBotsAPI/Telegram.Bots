// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

namespace Telegram.Bots.Types
{
  using Type = BotCommandScopeType;

  public abstract record BotCommandScope
  {
    public abstract BotCommandScopeType Type { get; }
  }

  public abstract record ChatBotCommandScope<TChatId> : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.Chat;

    public TChatId ChatId { get; }

    protected ChatBotCommandScope(TChatId chatId) => ChatId = chatId;
  }

  public abstract record ChatAdminsBotCommandScope<TChatId> : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.ChatAdministrators;

    public TChatId ChatId { get; }

    protected ChatAdminsBotCommandScope(TChatId chatId) => ChatId = chatId;
  }

  public abstract record ChatMemberBotCommandScope<TChatId> : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.ChatMember;

    public TChatId ChatId { get; }

    public long UserId { get; }

    protected ChatMemberBotCommandScope(TChatId chatId, long userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed record DefaultBotCommandScope : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.Default;
  }

  public sealed record AllPrivateChatsBotCommandScope : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.AllPrivateChats;
  }

  public sealed record AllGroupChatsBotCommandScope : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.AllGroupChats;
  }

  public sealed record AllChatAdminsBotCommandScope : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.AllChatAdministrators;
  }

  public sealed record ChatBotCommandScope : ChatBotCommandScope<long>
  {
    public ChatBotCommandScope(long chatId) : base(chatId) { }
  }

  public sealed record ChatAdminsBotCommandScope : ChatAdminsBotCommandScope<long>
  {
    public ChatAdminsBotCommandScope(long chatId) : base(chatId) { }
  }

  public sealed record ChatMemberBotCommandScope : ChatMemberBotCommandScope<long>
  {
    public ChatMemberBotCommandScope(long chatId, long userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed record ChatBotCommandScope : ChatBotCommandScope<string>
    {
      public ChatBotCommandScope(string chatId) : base(chatId) { }
    }

    public sealed record ChatAdminsBotCommandScope : ChatAdminsBotCommandScope<string>
    {
      public ChatAdminsBotCommandScope(string chatId) : base(chatId) { }
    }

    public sealed record ChatMemberBotCommandScope : ChatMemberBotCommandScope<string>
    {
      public ChatMemberBotCommandScope(string chatId, long userId) : base(chatId, userId) { }
    }
  }
}
