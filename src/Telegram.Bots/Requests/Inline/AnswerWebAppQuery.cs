// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2022 Aman Agnihotri

using Telegram.Bots.Types.Inline;

namespace Telegram.Bots.Requests.Inline
{
  public sealed record AnswerWebAppQuery : IRequest<SentWebAppMessage>
  {
    public string QueryId { get; }
    
    public InlineResult Result { get; }

    public string Method { get; } = "answerWebAppQuery";
    
    public AnswerWebAppQuery(string queryId, InlineResult result)
    {
      QueryId = queryId;
      Result = result;
    }
  }
}
