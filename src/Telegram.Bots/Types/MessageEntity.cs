// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed record MessageEntity
  {
    public MessageEntityType Type { get; init; }

    public uint Offset { get; init; }

    public uint Length { get; init; }

    public Uri? Url { get; init; }

    public User? User { get; init; }

    public string? Language { get; init; }
  }
}
