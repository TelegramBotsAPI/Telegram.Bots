using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class GetUserProfilePhotos : IRequest<UserProfilePhotos>, IUserTargetable
  {
    public int UserId { get; }

    public uint Offset { get; }

    public uint Limit { get; }

    public string Method { get; } = "getUserProfilePhotos";

    public GetUserProfilePhotos(int userId, uint offset, uint limit)
    {
      UserId = userId;
      Offset = offset;
      Limit = limit;
    }
  }
}
