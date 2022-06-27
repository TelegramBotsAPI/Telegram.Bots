// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record DeleteChatStickerSet<TChatId>(
    TChatId ChatId) : IRequest<bool>, IChatTargetable<TChatId>
  {
    public string Method => "deleteChatStickerSet";
  }

  public sealed record DeleteChatStickerSet(
    long ChatId) : DeleteChatStickerSet<long>(ChatId);

  namespace Usernames
  {
    public sealed record DeleteChatStickerSet(
      string ChatId) : DeleteChatStickerSet<string>(ChatId);
  }
}
