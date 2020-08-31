// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using Telegram.Bots.Types.Games;

namespace Telegram.Bots.Types
{
  public abstract class InlineButton
  {
    public string Text { get; }

    protected InlineButton(string text) => Text = text;
  }

  public sealed class UrlButton : InlineButton
  {
    public Uri Url { get; }

    public UrlButton(string text, Uri url) : base(text) => Url = url;
  }

  public sealed class LoginUrlButton : InlineButton
  {
    public LoginUrl LoginUrl { get; }

    public LoginUrlButton(string text, LoginUrl loginUrl) : base(text) => LoginUrl = loginUrl;
  }

  public sealed class CallbackDataButton : InlineButton
  {
    public string Data { get; }

    public CallbackDataButton(string text, string data) : base(text) => Data = data;
  }

  public sealed class SwitchInlineQueryButton : InlineButton
  {
    public string Query { get; }

    public SwitchInlineQueryButton(string text, string query) : base(text) => Query = query;
  }

  public sealed class SwitchInlineQueryCurrentChatButton : InlineButton
  {
    public string Query { get; }

    public SwitchInlineQueryCurrentChatButton(string text, string query) : base(text) =>
      Query = query;
  }

  public sealed class CallbackGameButton : InlineButton
  {
    public CallbackGame Game { get; } = CallbackGame.Default;

    public CallbackGameButton(string text) : base(text) { }
  }

  public sealed class PayButton : InlineButton
  {
    public bool Pay { get; } = true;

    public PayButton(string text) : base(text) { }
  }
}
