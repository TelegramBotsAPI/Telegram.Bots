namespace Telegram.Bots.Requests
{
  public interface IChatMemberTargetable<out TChatId> : IChatTargetable<TChatId>,
    IUserTargetable { }
}
