// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed record LoginUrl
  {
    public Uri Url { get; }

    public string? ForwardText { get; init; }

    public string? BotUsername { get; init; }

    public bool? RequestWriteAccess { get; init; }

    public LoginUrl(Uri url) => Url = url;
  }
}
