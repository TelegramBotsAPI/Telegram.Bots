// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  using System.Collections.Generic;
  using Types;

  public abstract record SetChatPhoto<TChatId>(
    TChatId ChatId,
    InputFile Photo) : IRequest<bool>, IChatTargetable<TChatId>, IUploadable
  {
    public string Method => "setChatPhoto";

    public IEnumerable<InputFile?> GetFiles()
    {
      return new[]
      {
        Photo
      };
    }
  }

  public sealed record SetChatPhoto(
    long ChatId,
    InputFile Photo) : SetChatPhoto<long>(ChatId, Photo);

  namespace Usernames
  {
    public sealed record SetChatPhoto(
      string ChatId,
      InputFile Photo) : SetChatPhoto<string>(ChatId, Photo);
  }
}
