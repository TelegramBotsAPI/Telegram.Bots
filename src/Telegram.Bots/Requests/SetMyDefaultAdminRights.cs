// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed record SetMyDefaultAdminRights : IRequest<bool>
  {
    public ChatAdminRights? Rights { get; init; }

    public bool? ForChannels { get; init; }

    public string Method { get; } = "setMyDefaultAdministratorRights";
  }
}
