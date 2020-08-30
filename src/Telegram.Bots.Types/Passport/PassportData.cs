// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;

namespace Telegram.Bots.Types.Passport
{
  public sealed class PassportData
  {
    public IReadOnlyList<EncryptedElement> Data { get; set; } = null!;

    public EncryptedCredentials Credentials { get; set; } = null!;
  }
}
