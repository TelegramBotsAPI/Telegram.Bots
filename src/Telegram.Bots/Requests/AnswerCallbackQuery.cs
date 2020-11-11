// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;

namespace Telegram.Bots.Requests
{
  public sealed record AnswerCallbackQuery : IRequest<bool>
  {
    public string QueryId { get; }

    public string Text { get; }

    public bool? ShowAlert { get; init; }

    public Uri? Url { get; init; }

    public int? CacheTime { get; init; }

    public string Method { get; } = "answerCallbackQuery";

    public AnswerCallbackQuery(string queryId, string text)
    {
      QueryId = queryId;
      Text = text;
    }
  }
}
