// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public abstract record Button
  {
    public string Text { get; }

    protected Button(string text) => Text = text;

    public static implicit operator Button(string text) => ToButton(text);

    public static Button ToButton(string text) => new TextButton(text);
  }

  public sealed record TextButton : Button
  {
    public TextButton(string text) : base(text) { }

    public static implicit operator TextButton(string text) => ToTextButton(text);

    public static TextButton ToTextButton(string text) => new(text);
  }

  public sealed record RequestContactButton : Button
  {
    public bool RequestContact { get; } = true;

    public RequestContactButton(string text) : base(text) { }
  }

  public sealed record RequestLocationButton : Button
  {
    public bool RequestLocation { get; } = true;

    public RequestLocationButton(string text) : base(text) { }
  }

  public sealed record RequestPollButton : Button
  {
    public ButtonPollType RequestPoll { get; } = ButtonPollType.AnyPoll;

    public RequestPollButton(string text) : base(text) { }
  }

  public sealed record RequestRegularPollButton : Button
  {
    public ButtonPollType? RequestPoll { get; } = new ButtonPollType(PollType.Regular);

    public RequestRegularPollButton(string text) : base(text) { }
  }

  public sealed record RequestQuizPollButton : Button
  {
    public ButtonPollType? RequestPoll { get; } = new ButtonPollType(PollType.Quiz);

    public RequestQuizPollButton(string text) : base(text) { }
  }
}
