namespace Telegram.Bots.Requests.Stickers
{
  public sealed class DeleteStickerFromSet : IRequest<bool>
  {
    public string Sticker { get; }

    public string Method { get; } = "deleteStickerFromSet";

    public DeleteStickerFromSet(string sticker) => Sticker = sticker;
  }
}
