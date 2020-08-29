namespace Telegram.Bots.Requests.Admins
{
  public abstract class PromoteChatMember<TChatId> : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public TChatId ChatId { get; }

    public int UserId { get; }

    public bool? CanChangeInfo { get; set; }

    public bool? CanPostMessages { get; set; }

    public bool? CanEditMessages { get; set; }

    public bool? CanDeleteMessages { get; set; }

    public bool? CanInviteUsers { get; set; }

    public bool? CanRestrictMembers { get; set; }

    public bool? CanPinMessages { get; set; }

    public bool? CanPromoteMembers { get; set; }

    public string Method { get; } = "promoteChatMember";

    protected PromoteChatMember(TChatId chatId, int userId)
    {
      ChatId = chatId;
      UserId = userId;
    }
  }

  public sealed class PromoteChatMember : PromoteChatMember<long>
  {
    public PromoteChatMember(long chatId, int userId) : base(chatId, userId) { }
  }

  namespace Usernames
  {
    public sealed class PromoteChatMember : PromoteChatMember<string>
    {
      public PromoteChatMember(string username, int userId) : base(username, userId) { }
    }
  }
}
