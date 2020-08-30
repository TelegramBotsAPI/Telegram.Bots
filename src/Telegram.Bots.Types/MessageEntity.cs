// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types
{
  public sealed class MessageEntity
  {
    public MessageEntityType Type { get; set; }

    public uint Offset { get; set; }

    public uint Length { get; set; }

    public Uri? Url { get; set; }

    public User? User { get; set; }

    public string? Language { get; set; }
  }
}
