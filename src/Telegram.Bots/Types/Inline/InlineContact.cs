// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Types.Inline
{
  public sealed record InlineContact : ReplaceableResult, IThumbable
  {
    public override ResultType Type { get; } = ResultType.Contact;

    public string PhoneNumber { get; }

    public string FirstName { get; }

    public string? LastName { get; init; }

    public string? Vcard { get; init; }

    public Uri? Thumb { get; init; }

    public int? ThumbWidth { get; init; }

    public int? ThumbHeight { get; init; }

    public InlineContact(string id, string phoneNumber, string firstName) : base(id)
    {
      PhoneNumber = phoneNumber;
      FirstName = firstName;
    }
  }
}
