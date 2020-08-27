using System;
using System.Collections.Generic;

namespace Telegram.Bots.Types.Webhooks
{
  public sealed class WebhookInfo
  {
    public Uri? Url { get; set; }

    public bool HasCustomCertificate { get; set; }

    public uint PendingUpdateCount { get; set; }

    public long? LastErrorDate { get; set; }

    public string? LastErrorMessage { get; set; }

    public uint? MaxConnections { get; set; }

    public IReadOnlyList<UpdateType>? AllowedUpdates { get; set; }
  }
}
