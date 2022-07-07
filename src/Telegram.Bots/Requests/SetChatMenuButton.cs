// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using Types;

public sealed record SetChatMenuButton : IRequest<bool>
{
  public long? ChatId { get; init; }

  public MenuButton? MenuButton { get; init; }

  public string Method => "setChatMenuButton";
}
