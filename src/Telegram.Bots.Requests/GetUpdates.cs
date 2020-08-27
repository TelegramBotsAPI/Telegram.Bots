using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class GetUpdates : IRequest<IReadOnlyList<Update>>
  {
    public int? Offset { get; set; }

    public int? Limit { get; set; }

    public int? Timeout { get; set; }

    public IEnumerable<UpdateType>? AllowedUpdates { get; set; }

    public string Method { get; } = "getUpdates";
  }
}
