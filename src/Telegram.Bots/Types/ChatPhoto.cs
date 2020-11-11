// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed record ChatPhoto
  {
    public string SmallFileId { get; init; } = null!;

    public string SmallFileUniqueId { get; init; } = null!;

    public string BigFileId { get; init; } = null!;

    public string BigFileUniqueId { get; init; } = null!;
  }
}
