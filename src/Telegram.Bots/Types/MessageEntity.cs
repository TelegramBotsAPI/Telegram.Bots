// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

using System;

public sealed record MessageEntity(
  MessageEntityType Type,
  uint Offset,
  uint Length)
{
  public Uri? Url { get; init; }

  public User? User { get; init; }

  public string? Language { get; init; }

  public string? CustomEmojiId { get; init; }
}
