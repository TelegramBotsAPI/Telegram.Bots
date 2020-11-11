// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed record GetUpdates : IRequest<IReadOnlyList<Update>>
  {
    public int? Offset { get; init; }

    public int? Limit { get; init; }

    public int? Timeout { get; init; }

    public IEnumerable<UpdateType>? AllowedUpdates { get; init; }

    public string Method { get; } = "getUpdates";
  }
}
