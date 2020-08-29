using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class SetMyCommands : IRequest<bool>
  {
    public IEnumerable<BotCommand> Commands { get; }

    public string Method { get; } = "setMyCommands";

    public SetMyCommands(IEnumerable<BotCommand> commands) => Commands = commands;
  }
}
