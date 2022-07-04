// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using Types;

public sealed record GetFile(string Id) : IRequest<FileInfo>
{
  public string Method => "getFile";
}
