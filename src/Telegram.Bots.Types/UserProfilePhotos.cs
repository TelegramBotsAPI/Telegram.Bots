// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed class UserProfilePhotos
  {
    public int TotalCount { get; set; }

    public IReadOnlyList<IReadOnlyList<Photo>> PhotoSets { get; set; } = null!;
  }
}
