using Telegram.Bots.Types;

namespace Telegram.Bots.Requests.Admins
{
  public abstract class RestrictChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public ChatPermissions Permissions { get; }

    public long? UntilDate { get; set; }

    public string Method { get; } = "restrictChatMember";

    protected RestrictChatMember(TChatId chatId, int userId, ChatPermissions permissions)
    {
      ChatId = chatId;
      UserId = userId;
      Permissions = permissions;
    }
  }

  public sealed class RestrictChatMember : RestrictChatMember<long>
  {
    public RestrictChatMember(long chatId, int userId, ChatPermissions permissions) :
      base(chatId, userId, permissions) { }
  }

  namespace Usernames
  {
    public sealed class RestrictChatMember : RestrictChatMember<string>
    {
      public RestrictChatMember(string username, int userId, ChatPermissions permissions) :
        base(username, userId, permissions) { }
    }
  }
}
