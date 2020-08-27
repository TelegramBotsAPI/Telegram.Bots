namespace Telegram.Bots.Requests
{
  public interface IRequest<TResult>
  {
    string Method { get; }
  }
}
