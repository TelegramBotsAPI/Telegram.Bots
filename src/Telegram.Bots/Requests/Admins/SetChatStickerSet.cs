// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record SetChatStickerSet<TChatId>(
    TChatId ChatId,
    string StickerSetName) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "setChatStickerSet";
  }

  public sealed record SetChatStickerSet(
    long ChatId,
    string StickerSetName) : SetChatStickerSet<long>(ChatId, StickerSetName);

  namespace Usernames
  {
    public sealed record SetChatStickerSet(
      string ChatId,
      string StickerSetName) :
      SetChatStickerSet<string>(ChatId, StickerSetName);
  }
}
