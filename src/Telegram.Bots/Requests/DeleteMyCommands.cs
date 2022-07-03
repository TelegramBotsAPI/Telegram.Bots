// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using Types;

public sealed record DeleteMyCommands : IRequest<bool>
{
  public BotCommandScope? Scope { get; init; }

  public string? LanguageCode { get; init; }

  public string Method => "deleteMyCommands";
}
