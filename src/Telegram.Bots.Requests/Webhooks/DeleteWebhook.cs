namespace Telegram.Bots.Requests.Webhooks
{
  public sealed class DeleteWebhook : IRequest<bool>
  {
    public string Method { get; } = "deleteWebhook";
  }
}
