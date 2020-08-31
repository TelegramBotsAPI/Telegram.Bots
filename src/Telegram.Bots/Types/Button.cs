// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public abstract class Button
  {
    public string Text { get; }

    protected Button(string text) => Text = text;

    public static implicit operator Button(string text) => ToButton(text);

    public static Button ToButton(string text) => new TextButton(text);
  }

  public sealed class TextButton : Button
  {
    public TextButton(string text) : base(text) { }

    public static implicit operator TextButton(string text) => ToTextButton(text);

    public static TextButton ToTextButton(string text) => new TextButton(text);
  }

  public sealed class RequestContactButton : Button
  {
    public bool RequestContact { get; } = true;

    public RequestContactButton(string text) : base(text) { }
  }

  public sealed class RequestLocationButton : Button
  {
    public bool RequestLocation { get; } = true;

    public RequestLocationButton(string text) : base(text) { }
  }

  public sealed class RequestPollButton : Button
  {
    public ButtonPollType RequestPoll { get; } = ButtonPollType.AnyPoll;

    public RequestPollButton(string text) : base(text) { }
  }

  public sealed class RequestRegularPollButton : Button
  {
    public ButtonPollType? RequestPoll { get; } = new ButtonPollType(PollType.Regular);

    public RequestRegularPollButton(string text) : base(text) { }
  }

  public sealed class RequestQuizPollButton : Button
  {
    public ButtonPollType? RequestPoll { get; } = new ButtonPollType(PollType.Quiz);

    public RequestQuizPollButton(string text) : base(text) { }
  }
}
