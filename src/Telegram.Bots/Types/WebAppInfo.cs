// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed record WebAppInfo
  {
    public Uri Url { get; }

    public WebAppInfo(Uri url) => Url = url;
  }
}
