// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Games
{
  using System.Collections.Generic;
  using Types.Games;

  public abstract record GetGameHighScoresBase(
    long UserId) : IRequest<IReadOnlyList<GameHighScore>>, IUserTargetable
  {
    public string Method => "getGameHighScores";
  }

  public abstract record GetGameHighScores<TChatId>(
    TChatId ChatId,
    int MessageId,
    long UserId) : GetGameHighScoresBase(UserId),
    IChatMessageTargetable<TChatId>;

  public sealed record GetGameHighScores(
    long ChatId,
    int MessageId,
    long UserId) : GetGameHighScores<long>(ChatId, MessageId, UserId);

  namespace Inline
  {
    public sealed record GetGameHighScores(
      string MessageId,
      long UserId) : GetGameHighScoresBase(UserId), IInlineMessageTargetable;
  }
}
