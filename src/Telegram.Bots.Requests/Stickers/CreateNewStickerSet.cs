using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract class CreateNewStickerSet : IRequest<bool>, IUserTargetable
  {
    public int UserId { get; }

    public string Name { get; }

    public string Title { get; }

    public string Emojis { get; }

    public bool? ContainsMasks { get; set; }

    public MaskPosition? MaskPosition { get; set; }

    public string Method { get; } = "createNewStickerSet";

    protected CreateNewStickerSet(int userId, string name, string title, string emojis)
    {
      UserId = userId;
      Name = name;
      Title = title;
      Emojis = emojis;
    }
  }

  public abstract class CreateNewPngStickerSet<TPngSticker> : CreateNewStickerSet
  {
    public TPngSticker Sticker { get; }

    protected CreateNewPngStickerSet(
      int userId,
      string name,
      string title,
      string emojis,
      TPngSticker sticker) : base(userId, name, title, emojis) => Sticker = sticker;
  }

  public sealed class CreateNewPngStickerSetViaCache : CreateNewPngStickerSet<string>
  {
    public CreateNewPngStickerSetViaCache(
      int userId,
      string name,
      string title,
      string emojis,
      string sticker) : base(userId, name, title, emojis, sticker) { }
  }

  public sealed class CreateNewPngStickerSetViaUrl : CreateNewPngStickerSet<Uri>
  {
    public CreateNewPngStickerSetViaUrl(
      int userId,
      string name,
      string title,
      string emojis,
      Uri sticker) : base(userId, name, title, emojis, sticker) { }
  }

  public sealed class CreateNewPngStickerSetViaFile : CreateNewPngStickerSet<InputFile>, IUploadable
  {
    public CreateNewPngStickerSetViaFile(
      int userId,
      string name,
      string title,
      string emojis,
      InputFile sticker) : base(userId, name, title, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }

  public abstract class CreateNewTgsStickerSet<TTgsSticker> : CreateNewStickerSet
  {
    public TTgsSticker Sticker { get; }

    protected CreateNewTgsStickerSet(
      int userId,
      string name,
      string title,
      string emojis,
      TTgsSticker sticker) : base(userId, name, title, emojis) => Sticker = sticker;
  }

  public sealed class CreateNewTgsStickerSetViaFile : CreateNewTgsStickerSet<InputFile>, IUploadable
  {
    public CreateNewTgsStickerSetViaFile(
      int userId,
      string name,
      string title,
      string emojis,
      InputFile sticker) : base(userId, name, title, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }
}
