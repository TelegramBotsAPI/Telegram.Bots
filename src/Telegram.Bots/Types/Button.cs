// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public abstract record Button(string Text)
{
  public static implicit operator Button(string text)
  {
    return ToButton(text);
  }

  public static Button ToButton(string text)
  {
    return new TextButton(text);
  }
}

public sealed record TextButton(string Text) : Button(Text)
{
  public static implicit operator TextButton(string text)
  {
    return ToTextButton(text);
  }

  public static TextButton ToTextButton(string text)
  {
    return new(text);
  }
}

public sealed record RequestContactButton(string Text) : Button(Text)
{
  public bool RequestContact => true;
}

public sealed record RequestLocationButton(string Text) : Button(Text)
{
  public bool RequestLocation => true;
}

public sealed record RequestPollButton(string Text) : Button(Text)
{
  public ButtonPollType RequestPoll => ButtonPollType.AnyPoll;
}

public sealed record RequestRegularPollButton(string Text) : Button(Text)
{
  public ButtonPollType RequestPoll => new ButtonPollType(PollType.Regular);
}

public sealed record RequestQuizPollButton(string Text) : Button(Text)
{
  public ButtonPollType RequestPoll => new ButtonPollType(PollType.Quiz);
}

public sealed record LaunchWebAppButton(
  string Text,
  WebAppInfo WebApp) : Button(Text);
