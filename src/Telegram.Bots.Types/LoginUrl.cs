// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed class LoginUrl
  {
    public Uri Url { get; }

    public string? ForwardText { get; set; }

    public string? BotUsername { get; set; }

    public bool? RequestWriteAccess { get; set; }

    public LoginUrl(Uri url) => Url = url;
  }
}
