// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Types.Passport
{
  public sealed record EncryptedCredentials
  {
    public string Data { get; init; } = null!;

    public string Hash { get; init; } = null!;

    public string Secret { get; init; } = null!;
  }
}
