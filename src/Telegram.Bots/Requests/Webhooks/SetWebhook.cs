// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Webhooks
{
  public sealed record SetWebhook : IRequest<bool>, IUploadable
  {
    public Uri? Url { get; }

    public InputFile? Certificate { get; init; }

    public string? IpAddress { get; init; }

    public uint? MaxConnections { get; init; }

    public IEnumerable<UpdateType>? AllowedUpdates { get; init; }

    public bool? DropPendingUpdates { get; init; }

    public string Method { get; } = "setWebhook";

    public SetWebhook(Uri? url = default) => Url = url;

    public IEnumerable<InputFile?> GetFiles() => new[] {Certificate};
  }
}
