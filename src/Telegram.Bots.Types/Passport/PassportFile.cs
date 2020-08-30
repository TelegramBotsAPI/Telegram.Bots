// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Passport
{
  public sealed class PassportFile
  {
    public string Id { get; set; } = null!;

    public string UniqueId { get; set; } = null!;

    public uint Size { get; set; }

    public DateTime Date { get; set; } = DateTime.UnixEpoch;
  }
}
