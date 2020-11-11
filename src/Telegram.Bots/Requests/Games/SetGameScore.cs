// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Games
{
  public abstract record SetGameScoreBase : IRequest<GameMessage>, IUserTargetable
  {
    public int UserId { get; }

    public uint Score { get; }

    public bool? Force { get; init; }

    public bool? DisableEdit { get; init; }

    public string Method { get; } = "setGameScore";

    protected SetGameScoreBase(int userId, uint score)
    {
      UserId = userId;
      Score = score;
    }
  }

  public abstract record SetGameScore<TChatId> : SetGameScoreBase, IChatMessageTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int MessageId { get; }

    protected SetGameScore(TChatId chatId, int messageId, int userId, uint score) :
      base(userId, score)
    {
      ChatId = chatId;
      MessageId = messageId;
    }
  }

  public sealed record SetGameScore : SetGameScore<long>
  {
    public SetGameScore(long chatId, int messageId, int userId, uint score) :
      base(chatId, messageId, userId, score) { }
  }

  namespace Inline
  {
    public sealed record SetGameScore : SetGameScoreBase, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public SetGameScore(string messageId, int userId, uint score) : base(userId, score) =>
        MessageId = messageId;
    }
  }
}
