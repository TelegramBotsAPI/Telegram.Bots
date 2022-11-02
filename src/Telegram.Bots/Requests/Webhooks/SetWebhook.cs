// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Webhooks;

using System;
using System.Collections.Generic;
using Types;

public sealed record SetWebhook(Uri Url) : IRequest<bool>, IUploadable
{
  public InputFile? Certificate { get; init; }

  public string? IpAddress { get; init; }

  public uint? MaxConnections { get; init; }

  public IEnumerable<UpdateType>? AllowedUpdates { get; init; }

  public bool? DropPendingUpdates { get; init; }

  public string? SecretToken { get; init; }

  public string Method => "setWebhook";

  public IEnumerable<InputFile?> GetFiles()
  {
    return new[]
    {
      Certificate
    };
  }
}
