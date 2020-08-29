using System.Collections.Generic;
using Telegram.Bots.Types.Games;

namespace Telegram.Bots.Requests.Games
{
  public abstract class GetGameHighScoresBase : IRequest<IReadOnlyList<GameHighScore>>,
    IUserTargetable
  {
    public int UserId { get; }

    public string Method { get; } = "getGameHighScores";

    protected GetGameHighScoresBase(int userId) => UserId = userId;
  }

  public abstract class GetGameHighScores<TChatId> : GetGameHighScoresBase,
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

  public sealed class GetGameHighScores : GetGameHighScores<long>
  {
    public GetGameHighScores(long chatId, int messageId, int userId) :
      base(chatId, messageId, userId) { }
  }

  namespace Inline
  {
    public sealed class GetGameHighScores : GetGameHighScoresBase, IInlineMessageTargetable
    {
      public string MessageId { get; }

      public GetGameHighScores(string messageId, int userId) : base(userId) =>
        MessageId = messageId;
    }
  }
}
