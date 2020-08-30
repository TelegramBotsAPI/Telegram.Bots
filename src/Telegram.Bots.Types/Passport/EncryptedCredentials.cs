// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Passport
{
  public sealed class EncryptedCredentials
  {
    public string Data { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public string Secret { get; set; } = null!;
  }
}
