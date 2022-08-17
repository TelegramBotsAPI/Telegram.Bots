// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public abstract record MenuButton
{
  public abstract MenuButtonType Type { get; }
}

public sealed record DefaultMenuButton : MenuButton
{
  public override MenuButtonType Type => MenuButtonType.Default;
}

public sealed record CommandsMenuButton : MenuButton
{
  public override MenuButtonType Type => MenuButtonType.Commands;
}

public sealed record WebAppMenuButton : MenuButton
{
  public override MenuButtonType Type => MenuButtonType.WebApp;

  public string Text { get; }

  public WebAppInfo WebApp { get; }

  public WebAppMenuButton(string text, WebAppInfo webApp)
  {
    Text = text;
    WebApp = webApp;
  }
}
