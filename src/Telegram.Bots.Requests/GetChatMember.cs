using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class GetChatMember<TChatId> : IRequest<ChatMember>,
    IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public string Method { get; } = "getChatMember";

    protected GetChatMember(TChatId chatId, int userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed class GetChatMember : GetChatMember<long>
  {
    public GetChatMember(long chatId, int userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed class GetChatMember : GetChatMember<string>
    {
      public GetChatMember(string username, int userId) : base(username, userId) { }
    }
  }
}
