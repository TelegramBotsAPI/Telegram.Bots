// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Webhooks;

using Types.Webhooks;

public sealed record GetWebhookInfo : IRequest<WebhookInfo>
{
  public string Method => "getWebhookInfo";
}
