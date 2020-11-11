// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Payments
{
  public sealed record ShippingOption
  {
    public string Id { get; init; } = null!;

    public string Title { get; init; } = null!;

    public IReadOnlyList<LabeledPrice> Prices { get; init; } = null!;
  }
}
