// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using Types;

public sealed record GetChatMenuButton : IRequest<MenuButton>
{
  public long? ChatId { get; init; }

  public string Method => "getChatMenuButton";
}
