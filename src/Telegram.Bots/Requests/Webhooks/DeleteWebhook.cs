// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Webhooks
{
  public sealed class DeleteWebhook : IRequest<bool>
  {
    public bool? DropPendingUpdates { get; set; }

    public string Method { get; } = "deleteWebhook";
  }
}
