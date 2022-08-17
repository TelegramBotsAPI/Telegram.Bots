// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;

public sealed record LoginUrl(Uri Url)
{
  public string? ForwardText { get; init; }

  public string? BotUsername { get; init; }

  public bool? RequestWriteAccess { get; init; }
}
