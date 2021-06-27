// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed record SetMyCommands : IRequest<bool>
  {
    public IEnumerable<BotCommand> Commands { get; }

    public BotCommandScope? Scope { get; init; }

    public string? LanguageCode { get; init; }

    public string Method { get; } = "setMyCommands";

    public SetMyCommands(IEnumerable<BotCommand> commands) => Commands = commands;
  }
}
