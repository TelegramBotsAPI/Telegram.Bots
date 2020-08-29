using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public sealed class GetStickerSet : IRequest<StickerSet>
  {
    public string Name { get; }

    public string Method { get; } = "getStickerSet";

    public GetStickerSet(string name) => Name = name;
  }
}
