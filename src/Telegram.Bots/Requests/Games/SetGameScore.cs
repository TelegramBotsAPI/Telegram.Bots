// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Games
{
  public abstract class SetGameScoreBase : IRequest<GameMessage>, IUserTargetable
  {
    public int UserId { get; }

    public uint Score { get; }

    public bool? Force { get; set; }

    public bool? DisableEdit { get; set; }

    public string Method { get; } = "setGameScore";

    protected SetGameScoreBase(int userId, uint score)
    {
      UserId = userId;
      Score = score;
    }
  }

  public abstract class SetGameScore<TChatId> : SetGameScoreBase, IChatMessageTargetable<TChatId>
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

  public sealed class SetGameScore : SetGameScore<long>
  {
    public SetGameScore(long chatId, int messageId, int userId, uint score) :
      base(chatId, messageId, userId, score) { }
  }

  namespace Inline
  {
    public sealed class SetGameScore : SetGameScoreBase, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public SetGameScore(string messageId, int userId, uint score) : base(userId, score) =>
        MessageId = messageId;
    }
  }
}
