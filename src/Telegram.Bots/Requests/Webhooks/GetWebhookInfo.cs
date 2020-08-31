// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types.Webhooks;

namespace Telegram.Bots.Requests.Webhooks
{
  public sealed class GetWebhookInfo : IRequest<WebhookInfo>
  {
    public string Method { get; } = "getWebhookInfo";
  }
}
