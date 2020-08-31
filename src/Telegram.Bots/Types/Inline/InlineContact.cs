// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed class InlineContact : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Contact;

    public string PhoneNumber { get; }

    public string FirstName { get; }

    public string? LastName { get; set; }

    public string? Vcard { get; set; }

    public Uri? Thumb { get; set; }

    public int? ThumbWidth { get; set; }

    public int? ThumbHeight { get; set; }

    public InlineContact(string id, string phoneNumber, string firstName) : base(id)
    {
      PhoneNumber = phoneNumber;
      FirstName = firstName;
    }
  }
}
