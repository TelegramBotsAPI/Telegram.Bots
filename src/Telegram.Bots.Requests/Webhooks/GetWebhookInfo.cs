using Telegram.Bots.Types.Webhooks;

namespace Telegram.Bots.Requests.Webhooks
{
  public sealed class GetWebhookInfo : IRequest<WebhookInfo>
  {
    public string Method { get; } = "getWebhookInfo";
  }
}
