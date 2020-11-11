// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed record GetUserProfilePhotos : IRequest<UserProfilePhotos>, IUserTargetable
  {
    public int UserId { get; }

    public uint Offset { get; }

    public uint Limit { get; }

    public string Method { get; } = "getUserProfilePhotos";

    public GetUserProfilePhotos(int userId, uint offset, uint limit)
    {
      UserId = userId;
      Offset = offset;
      Limit = limit;
    }
  }
}
