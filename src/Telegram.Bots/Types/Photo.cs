// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record Photo : File
  {
    public int Width { get; init; }

    public int Height { get; init; }
  }
}
