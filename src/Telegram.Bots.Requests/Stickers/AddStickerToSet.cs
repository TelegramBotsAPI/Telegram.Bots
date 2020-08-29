using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Requests.Stickers
{
  public abstract class AddStickerToSet : IRequest<bool>, IUserTargetable
  {
    public int UserId { get; }

    public string Name { get; }

    public string Emojis { get; }

    public MaskPosition? MaskPosition { get; set; }

    public string Method { get; } = "addStickerToSet";

    protected AddStickerToSet(int userId, string name, string emojis)
    {
      UserId = userId;
      Name = name;
      Emojis = emojis;
    }
  }

  public abstract class AddPngStickerToSet<TPngSticker> : AddStickerToSet
  {
    public TPngSticker Sticker { get; }

    protected AddPngStickerToSet(int userId, string name, string emojis, TPngSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed class AddPngStickerToSetViaCache : AddPngStickerToSet<string>
  {
    public AddPngStickerToSetViaCache(int userId, string name, string emojis, string sticker) :
      base(userId, name, emojis, sticker) { }
  }

  public sealed class AddPngStickerToSetViaUrl : AddPngStickerToSet<Uri>
  {
    public AddPngStickerToSetViaUrl(int userId, string name, string emojis, Uri sticker) :
      base(userId, name, emojis, sticker) { }
  }

  public sealed class AddPngStickerToSetViaFile : AddPngStickerToSet<InputFile>, IUploadable
  {
    public AddPngStickerToSetViaFile(int userId, string name, string emojis, InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }

  public abstract class AddTgsStickerToSet<TTgsSticker> : AddStickerToSet
  {
    public TTgsSticker Sticker { get; }

    protected AddTgsStickerToSet(int userId, string name, string emojis, TTgsSticker sticker) :
      base(userId, name, emojis) => Sticker = sticker;
  }

  public sealed class AddTgsStickerToSetViaFile : AddTgsStickerToSet<InputFile>, IUploadable
  {
    public AddTgsStickerToSetViaFile(int userId, string name, string emojis, InputFile sticker) :
      base(userId, name, emojis, sticker) { }

    public IEnumerable<InputFile?> GetFiles() => new[] { Sticker };
  }
}
