// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System.Collections.Generic;
using Telegram.Bots.Types.Games;

namespace Telegram.Bots.Requests.Games
{
  public abstract record GetGameHighScoresBase : IRequest<IReadOnlyList<GameHighScore>>,
    IUserTargetable
  {
    public int UserId { get; }

    public string Method { get; } = "getGameHighScores";

    protected GetGameHighScoresBase(int userId) => UserId = userId;
  }

  public abstract record GetGameHighScores<TChatId> : GetGameHighScoresBase,
    IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected GetGameHighScores(TChatId chatId, int messageId, int userId) : base(userId)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed record GetGameHighScores : GetGameHighScores<long>
  {
    public GetGameHighScores(long chatId, int messageId, int userId) :
      base(chatId, messageId, userId) { }
  }

  namespace Inline
  {
    public sealed record GetGameHighScores : GetGameHighScoresBase, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public GetGameHighScores(string messageId, int userId) : base(userId) =>
        MessageId = messageId;
    }
  }
}
