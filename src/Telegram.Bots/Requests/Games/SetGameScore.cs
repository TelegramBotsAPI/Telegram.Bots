// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Games
{
  using Types;

  public abstract record SetGameScoreBase(
    long UserId,
    uint Score) : IRequest<GameMessage>, IUserTargetable
  {
    public bool? Force { get; init; }

    public bool? DisableEdit { get; init; }

    public string Method => "setGameScore";
  }

  public abstract record SetGameScore<TChatId>(
    TChatId ChatId,
    int MessageId,
    long UserId,
    uint Score) : SetGameScoreBase(UserId, Score),
    IChatMessageTargetable<TChatId>;

  public sealed record SetGameScore(
    long ChatId,
    int MessageId,
    long UserId,
    uint Score) : SetGameScore<long>(ChatId, MessageId, UserId, Score);

  namespace Inline
  {
    public sealed record SetGameScore(
      string MessageId,
      long UserId,
      uint Score) : SetGameScoreBase(UserId, Score), IInlineMessageTargetable;
  }
}
