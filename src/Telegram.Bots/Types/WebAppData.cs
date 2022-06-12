// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record WebAppData
  {
    public string Data { get; init; } = null!;
    
    public string ButtonText { get; init; } = null!;
  }
}
