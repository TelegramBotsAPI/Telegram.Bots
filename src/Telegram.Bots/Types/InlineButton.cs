// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System;
using Telegram.Bots.Types.Games;

namespace Telegram.Bots.Types
{
  public abstract record InlineButton
  {
    public string Text { get; }

    protected InlineButton(string text) => Text = text;
  }

  public sealed record UrlButton : InlineButton
  {
    public Uri Url { get; }

    public UrlButton(string text, Uri url) : base(text) => Url = url;
  }

  public sealed record LoginUrlButton : InlineButton
  {
    public LoginUrl LoginUrl { get; }

    public LoginUrlButton(string text, LoginUrl loginUrl) : base(text) => LoginUrl = loginUrl;
  }
  
  public sealed record WebAppButton : InlineButton
  {
    public WebAppInfo WebApp { get; }

    public WebAppButton(string text, WebAppInfo webApp) : base(text) => WebApp = webApp;
  }

  public sealed record CallbackDataButton : InlineButton
  {
    public string Data { get; }

    public CallbackDataButton(string text, string data) : base(text) => Data = data;
  }

  public sealed record SwitchInlineQueryButton : InlineButton
  {
    public string Query { get; }

    public SwitchInlineQueryButton(string text, string query) : base(text) => Query = query;
  }

  public sealed record SwitchInlineQueryCurrentChatButton : InlineButton
  {
    public string Query { get; }

    public SwitchInlineQueryCurrentChatButton(string text, string query) : base(text) =>
      Query = query;
  }

  public sealed record CallbackGameButton : InlineButton
  {
    public CallbackGame Game { get; } = CallbackGame.Default;

    public CallbackGameButton(string text) : base(text) { }
  }

  public sealed record PayButton : InlineButton
  {
    public bool Pay { get; } = true;

    public PayButton(string text) : base(text) { }
  }
}
