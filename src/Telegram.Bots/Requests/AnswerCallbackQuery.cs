// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests;

using System;

public sealed record AnswerCallbackQuery(
  string QueryId,
  string Text) : IRequest<bool>
{
  public bool? ShowAlert { get; init; }

  public Uri? Url { get; init; }

  public int? CacheTime { get; init; }

  public string Method => "answerCallbackQuery";
}
