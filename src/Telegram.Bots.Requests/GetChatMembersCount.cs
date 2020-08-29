namespace Telegram.Bots.Requests
{
  public abstract class GetChatMembersCount<TChatId> : IRequest<uint>, IChatTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public string Method { get; } = "getChatMembersCount";

    protected GetChatMembersCount(TChatId chatId) => ChatId = chatId;
  }

  public sealed class GetChatMembersCount : GetChatMembersCount<long>
  {
    public GetChatMembersCount(long chatId) : base(chatId) { }
  }

  namespace Usernames
  {
    public sealed class GetChatMembersCount : GetChatMembersCount<string>
    {
      public GetChatMembersCount(string username) : base(username) { }
    }
  }
}
