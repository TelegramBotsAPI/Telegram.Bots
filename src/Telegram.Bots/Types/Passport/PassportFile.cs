// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Passport
{
  public sealed record PassportFile
  {
    public string Id { get; init; } = null!;

    public string UniqueId { get; init; } = null!;

    public uint Size { get; init; }

    public DateTime Date { get; init; } = DateTime.UnixEpoch;
  }
}
