// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Types
{
  using Type = BotCommandScopeType;

  public abstract record BotCommandScope
  {
    public abstract BotCommandScopeType Type { get; }
  }

  public abstract record ChatBotCommandScope<TChatId>(
    TChatId ChatId) : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.Chat;
  }

  public abstract record ChatAdminsBotCommandScope<TChatId>(
    TChatId ChatId) : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.ChatAdministrators;
  }

  public abstract record ChatMemberBotCommandScope<TChatId>(
    TChatId ChatId,
    long UserId) : BotCommandScope
  {
    public override BotCommandScopeType Type => Type.ChatMember;
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

  public sealed record ChatBotCommandScope(
    long ChatId) : ChatBotCommandScope<long>(ChatId);

  public sealed record ChatAdminsBotCommandScope(
    long ChatId) : ChatAdminsBotCommandScope<long>(ChatId);

  public sealed record ChatMemberBotCommandScope(
    long ChatId,
    long UserId) : ChatMemberBotCommandScope<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record ChatBotCommandScope(
      string ChatId) : ChatBotCommandScope<string>(ChatId);

    public sealed record ChatAdminsBotCommandScope(
      string ChatId) : ChatAdminsBotCommandScope<string>(ChatId);

    public sealed record ChatMemberBotCommandScope(
      string ChatId,
      long UserId) : ChatMemberBotCommandScope<string>(ChatId, UserId);
  }
}
