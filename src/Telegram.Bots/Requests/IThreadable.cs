// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

internal interface IThreadable
{
  public int? ThreadId { get; init; }
}
