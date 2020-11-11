// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed record UserProfilePhotos
  {
    public int TotalCount { get; init; }

    public IReadOnlyList<IReadOnlyList<Photo>> PhotoSets { get; init; } = null!;
  }
}
