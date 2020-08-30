// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public sealed class GetFile : IRequest<FileInfo>
  {
    public string Id { get; }

    public string Method { get; } = "getFile";

    public GetFile(string id) => Id = id;
  }
}
