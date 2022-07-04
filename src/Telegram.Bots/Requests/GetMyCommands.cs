// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using System.Collections.Generic;
using Types;

public sealed record GetMyCommands : IRequest<IReadOnlyList<BotCommand>>
{
  public BotCommandScope? Scope { get; init; }

  public string? LanguageCode { get; init; }

  public string Method => "getMyCommands";
}
