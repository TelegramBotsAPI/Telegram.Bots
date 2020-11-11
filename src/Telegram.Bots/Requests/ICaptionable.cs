// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public interface ICaptionable
  {
    string? Caption { get; init; }

    ParseMode? ParseMode { get; init; }

    IEnumerable<MessageEntity>? CaptionEntities { get; init; }
  }
}
