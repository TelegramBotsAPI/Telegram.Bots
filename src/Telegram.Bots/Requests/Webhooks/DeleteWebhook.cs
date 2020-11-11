// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Webhooks
{
  public sealed record DeleteWebhook : IRequest<bool>
  {
    public bool? DropPendingUpdates { get; init; }

    public string Method { get; } = "deleteWebhook";
  }
}
