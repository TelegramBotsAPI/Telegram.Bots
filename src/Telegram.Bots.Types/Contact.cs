// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types
{
  public sealed class Contact
  {
    public string PhoneNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int? UserId { get; set; }

    public string? Vcard { get; set; }
  }
}
