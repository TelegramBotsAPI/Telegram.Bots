// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Passport
{
  public abstract class EncryptedElement
  {
    public abstract ElementType Type { get; }

    public string Hash { get; set; } = null!;
  }

  public abstract class EncryptedDocument : EncryptedElement
  {
    public IReadOnlyList<PassportFile> Files { get; set; } = null!;

    public IReadOnlyList<PassportFile>? Translation { get; set; }
  }

  public abstract class EncryptedIdentityDocument : EncryptedElement
  {
    public string Data { get; set; } = null!;

    public PassportFile FrontSide { get; set; } = null!;

    public PassportFile ReverseSide { get; set; } = null!;

    public IReadOnlyList<PassportFile>? Translation { get; set; }
  }

  public abstract class EncryptedIdentityDocumentWithSelfie : EncryptedIdentityDocument
  {
    public PassportFile Selfie { get; set; } = null!;
  }

  public sealed class EncryptedPersonalDetails : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.PersonalDetails;

    public string Data { get; set; } = null!;
  }

  public sealed class EncryptedPassport : EncryptedIdentityDocument
  {
    public override ElementType Type { get; } = ElementType.Passport;
  }

  public sealed class EncryptedDriverLicense : EncryptedIdentityDocumentWithSelfie
  {
    public override ElementType Type { get; } = ElementType.DriverLicense;
  }

  public sealed class EncryptedIdentityCard : EncryptedIdentityDocumentWithSelfie
  {
    public override ElementType Type { get; } = ElementType.IdentityCard;
  }

  public sealed class EncryptedInternalPassport : EncryptedIdentityDocument
  {
    public override ElementType Type { get; } = ElementType.InternalPassport;
  }

  public sealed class EncryptedAddress : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.Address;

    public string Data { get; set; } = null!;
  }

  public sealed class EncryptedUtilityBill : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.UtilityBill;
  }

  public sealed class EncryptedBankStatement : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.BankStatement;
  }

  public sealed class EncryptedRentalAgreement : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.RentalAgreement;
  }

  public sealed class EncryptedPassportRegistration : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.PassportRegistration;
  }

  public sealed class EncryptedTemporaryRegistration : EncryptedDocument
  {
    public override ElementType Type { get; } = ElementType.TemporaryRegistration;
  }

  public sealed class EncryptedPhoneNumber : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.PhoneNumber;

    public string PhoneNumber { get; set; } = null!;
  }

  public sealed class EncryptedEmail : EncryptedElement
  {
    public override ElementType Type { get; } = ElementType.Email;

    public string Email { get; set; } = null!;
  }
}
