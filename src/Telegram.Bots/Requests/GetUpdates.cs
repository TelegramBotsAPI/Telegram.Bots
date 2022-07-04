// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using System.Collections.Generic;
using Types;

public sealed record GetUpdates : IRequest<IReadOnlyList<Update>>
{
  public int? Offset { get; init; }

  public int? Limit { get; init; }

  public int? Timeout { get; init; }

  public IEnumerable<UpdateType>? AllowedUpdates { get; init; }

  public string Method => "getUpdates";
}
