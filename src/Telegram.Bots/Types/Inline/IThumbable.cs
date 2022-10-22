// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Inline;

using System;

public interface IThumbable
{
  public Uri? Thumb { get; init; }

  public int? ThumbWidth { get; init; }

  public int? ThumbHeight { get; init; }
}
