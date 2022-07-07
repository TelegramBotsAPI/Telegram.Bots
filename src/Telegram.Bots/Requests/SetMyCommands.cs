// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using System.Collections.Generic;
using Types;

public sealed record SetMyCommands(
  IEnumerable<BotCommand> Commands) : IRequest<bool>
{
  public BotCommandScope? Scope { get; init; }

  public string? LanguageCode { get; init; }

  public string Method => "setMyCommands";
}
