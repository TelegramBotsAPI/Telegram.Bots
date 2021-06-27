// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2021 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed record DeleteMyCommands : IRequest<bool>
  {
    public BotCommandScope? Scope { get; init; }

    public string? LanguageCode { get; init; }

    public string Method { get; } = "deleteMyCommands";
  }
}
