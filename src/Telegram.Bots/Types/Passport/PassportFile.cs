// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Passport;

using System;

public sealed record PassportFile
{
  public string Id { get; init; } = null!;

  public string UniqueId { get; init; } = null!;

  public uint Size { get; init; }

  public DateTime Date { get; init; } = DateTime.UnixEpoch;
}
