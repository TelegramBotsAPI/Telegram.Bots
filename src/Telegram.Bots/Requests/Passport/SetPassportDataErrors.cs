// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Passport;

using System.Collections.Generic;
using Types.Passport;

public sealed record SetPassportDataErrors(
  long UserId,
  IEnumerable<ElementError> Errors) : IRequest<bool>, IUserTargetable
{
  public string Method => "setPassportDataErrors";
}
