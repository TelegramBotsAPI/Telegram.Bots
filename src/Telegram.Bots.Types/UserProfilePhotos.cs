using System.Collections.Generic;

namespace Telegram.Bots.Types
{
  public sealed class UserProfilePhotos
  {
    public int TotalCount { get; set; }

    public IReadOnlyList<IReadOnlyList<Photo>> PhotoSets { get; set; } = null!;
  }
}
