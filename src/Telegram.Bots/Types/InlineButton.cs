// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using Games;
using System;

public abstract record InlineButton(string Text);

public sealed record UrlButton(
  string Text,
  Uri Url) : InlineButton(Text);

public sealed record LoginUrlButton(
  string Text,
  LoginUrl LoginUrl) : InlineButton(Text);

public sealed record WebAppButton(
  string Text,
  WebAppInfo WebApp) : InlineButton(Text);

public sealed record CallbackDataButton(
  string Text,
  string Data) : InlineButton(Text);

public sealed record SwitchInlineQueryButton(
  string Text,
  string Query) : InlineButton(Text);

public sealed record SwitchInlineQueryCurrentChatButton(
  string Text,
  string Query) : InlineButton(Text);

public sealed record CallbackGameButton(string Text) : InlineButton(Text)
{
  public CallbackGame Game => CallbackGame.Default;
}

public sealed record PayButton(string Text) : InlineButton(Text)
{
  public bool Pay => true;
}
