// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public interface IThumbable
  {
    public Uri? Thumb { get; init; }

    public int? ThumbWidth { get; init; }

    public int? ThumbHeight { get; init; }
  }
}
