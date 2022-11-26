// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types;

public sealed record Contact
{
  public string PhoneNumber { get; init; } = null!;

  public string FirstName { get; init; } = null!;

  public string? LastName { get; init; }

  public long? UserId { get; init; }

  public string? Vcard { get; init; }
}
