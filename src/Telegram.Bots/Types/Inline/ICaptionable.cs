// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Inline
{
  public interface ICaptionable
  {
    string? Caption { get; init; }

    ParseMode? ParseMode { get; init; }

    IEnumerable<MessageEntity>? CaptionEntities { get; init; }
  }
}
