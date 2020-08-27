using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class GetMe : IRequest<MyBot>
  {
    public string Method { get; } = "getMe";
  }
}
