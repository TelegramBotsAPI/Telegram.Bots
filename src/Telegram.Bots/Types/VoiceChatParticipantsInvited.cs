using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed record VoiceChatParticipantsInvited
  {
    public IReadOnlyList<User>? Users { get; init; }
  }
}
