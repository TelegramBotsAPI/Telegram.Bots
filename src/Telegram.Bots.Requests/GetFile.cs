using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class GetFile : IRequest<FileInfo>
  {
    public string Id { get; }

    public GetFile(string id) => Id = id;

    public string Method { get; } = "getFile";
  }
}
