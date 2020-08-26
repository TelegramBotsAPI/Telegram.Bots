using System;
using Telegram.Bots.Types.Games;

namespace Telegram.Bots.Types
{
  public abstract class InlineKeyboardButton
  {
    public string Text { get; }

    protected InlineKeyboardButton(string text) => Text = text;
  }

  public sealed class UrlButton : InlineKeyboardButton
  {
    public Uri Url { get; }

    public UrlButton(string text, Uri url) : base(text) => Url = url;
  }

  public sealed class LoginUrlButton : InlineKeyboardButton
  {
    public LoginUrl LoginUrl { get; }

    public LoginUrlButton(string text, LoginUrl loginUrl) : base(text) => LoginUrl = loginUrl;
  }

  public sealed class CallbackDataButton : InlineKeyboardButton
  {
    public string Data { get; }

    public CallbackDataButton(string text, string data) : base(text) => Data = data;
  }

  public sealed class SwitchInlineQueryButton : InlineKeyboardButton
  {
    public string Query { get; }

    public SwitchInlineQueryButton(string text, string query) : base(text) => Query = query;
  }

  public sealed class SwitchInlineQueryCurrentChatButton : InlineKeyboardButton
  {
    public string Query { get; }

    public SwitchInlineQueryCurrentChatButton(string text, string query) : base(text) =>
      Query = query;
  }

  public sealed class CallbackGameButton : InlineKeyboardButton
  {
    public CallbackGame Game { get; } = CallbackGame.Default;

    public CallbackGameButton(string text) : base(text) { }
  }

  public sealed class PayButton : InlineKeyboardButton
  {
    public bool Pay { get; } = true;

    public PayButton(string text) : base(text) { }
  }
}
