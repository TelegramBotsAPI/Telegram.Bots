// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Passport
{
  public abstract record EncryptedElement
  {
    public abstract ElementType Type { get; }

    public string Hash { get; init; } = null!;
  }

  public abstract record EncryptedDocument : EncryptedElement
  {
    public IReadOnlyList<PassportFile> Files { get; init; } = null!;

    public IReadOnlyList<PassportFile>? Translation { get; init; }
  }

  public abstract record EncryptedIdentityDocument : EncryptedElement
  {
    public string Data { get; init; } = null!;

    public PassportFile FrontSide { get; init; } = null!;

    public PassportFile ReverseSide { get; init; } = null!;

    public IReadOnlyList<PassportFile>? Translation { get; init; }
  }

  public abstract record EncryptedIdentityDocumentWithSelfie : EncryptedIdentityDocument
  {
    public PassportFile Selfie { get; init; } = null!;
  }

  public sealed record EncryptedPersonalDetails : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.PersonalDetails;

    public string Data { get; init; } = null!;
  }

  public sealed record EncryptedPassport : EncryptedIdentityDocument
  {
    public override ElementType Type { get; } = ElementType.Passport;
  }

  public sealed record EncryptedDriverLicense : EncryptedIdentityDocumentWithSelfie
  {
    public override ElementType Type { get; } = ElementType.DriverLicense;
  }

  public sealed record EncryptedIdentityCard : EncryptedIdentityDocumentWithSelfie
  {
    public override ElementType Type { get; } = ElementType.IdentityCard;
  }

  public sealed record EncryptedInternalPassport : EncryptedIdentityDocument
  {
    public override ElementType Type { get; } = ElementType.InternalPassport;
  }

  public sealed record EncryptedAddress : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.Address;

    public string Data { get; init; } = null!;
  }

  public sealed record EncryptedUtilityBill : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.UtilityBill;
  }

  public sealed record EncryptedBankStatement : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.BankStatement;
  }

  public sealed record EncryptedRentalAgreement : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.RentalAgreement;
  }

  public sealed record EncryptedPassportRegistration : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.PassportRegistration;
  }

  public sealed record EncryptedTemporaryRegistration : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.TemporaryRegistration;
  }

  public sealed record EncryptedPhoneNumber : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.PhoneNumber;

    public string PhoneNumber { get; init; } = null!;
  }

  public sealed record EncryptedEmail : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.Email;

    public string Email { get; init; } = null!;
  }
}
