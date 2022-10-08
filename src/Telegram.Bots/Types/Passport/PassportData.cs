// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Types.Passport;

using System.Collections.Generic;

public sealed record PassportData(
  IReadOnlyList<EncryptedElement> Data,
  EncryptedCredentials Credentials);
