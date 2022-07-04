// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using Types;

public sealed record GetMyDefaultAdminRights : IRequest<ChatAdminRights>
{
  public bool? ForChannels { get; init; }

  public string Method => "getMyDefaultAdministratorRights";
}
