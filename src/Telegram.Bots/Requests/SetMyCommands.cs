// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed record SetMyCommands : IRequest<bool>
  {
    public IEnumerable<BotCommand> Commands { get; }

    public string Method { get; } = "setMyCommands";

    public SetMyCommands(IEnumerable<BotCommand> commands) => Commands = commands;
  }
}
