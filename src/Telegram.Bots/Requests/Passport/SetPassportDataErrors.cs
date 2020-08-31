// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types.Passport;

namespace Telegram.Bots.Requests.Passport
{
  public sealed class SetPassportDataErrors : IRequest<bool>, IUserTargetable
  {
    public int UserId { get; }

    public IEnumerable<ElementError> Errors { get; }

    public string Method { get; } = "setPassportDataErrors";

    public SetPassportDataErrors(int userId, IEnumerable<ElementError> errors)
    {
      UserId = userId;
      Errors = errors;
    }
  }
}
