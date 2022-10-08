// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Passport;

public sealed record EncryptedCredentials(
  string Data,
  string Hash,
  string Secret);
