using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class GetMyCommands : IRequest<IReadOnlyList<BotCommand>>
  {
    public string Method { get; } = "getMyCommands";
  }
}
