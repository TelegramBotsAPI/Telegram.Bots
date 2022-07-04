// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using System.Collections.Generic;
using Types;

public interface ICaptionable
{
  string? Caption { get; init; }

  ParseMode? ParseMode { get; init; }

  IEnumerable<MessageEntity>? CaptionEntities { get; init; }
}
