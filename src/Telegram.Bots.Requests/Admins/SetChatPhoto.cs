// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract class SetChatPhoto<TChatId> : IRequest<bool>, IChatTargetable<TChatId>,
    IUploadable
  {
    public TChatId ChatId { get; }

    public InputFile Photo { get; }

    public string Method { get; } = "setChatPhoto";

    protected SetChatPhoto(TChatId chatId, InputFile photo)
    {
      ChatId = chatId;
      Photo = photo;
    }

    public IEnumerable<InputFile?> GetFiles() => new[] { Photo };
  }

  public sealed class SetChatPhoto : SetChatPhoto<long>
  {
    public SetChatPhoto(long chatId, InputFile photo) : base(chatId, photo) { }
  }

  namespace Usernames
  {
    public sealed class SetChatPhoto : SetChatPhoto<string>
    {
      public SetChatPhoto(string username, InputFile photo) : base(username, photo) { }
    }
  }
}
