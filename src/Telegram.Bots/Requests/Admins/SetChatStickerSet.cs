// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract class SetChatStickerSet<TChatId> : IRequest<bool>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string StickerSetName { get; }

    public string Method { get; } = "setChatStickerSet";

    protected SetChatStickerSet(TChatId chatId, string stickerSetName)
    {
      ChatId = chatId;
      StickerSetName = stickerSetName;
    }
  }

  public sealed class SetChatStickerSet : SetChatStickerSet<long>
  {
    public SetChatStickerSet(long chatId, string stickerSetName) : base(chatId, stickerSetName) { }
  }

  namespace Usernames
  {
    public sealed class SetChatStickerSet : SetChatStickerSet<string>
    {
      public SetChatStickerSet(string username, string stickerSetName) :
        base(username, stickerSetName) { }
    }
  }
}
