namespace Telegram.Bots.Types
{
  public sealed class Either<TL, TR>
  {
    public TL Left { get; } = default!;

    public TR Right { get; } = default!;

    public bool IsLeft { get; }

    private Either(TL left)
    {
      Left = left;
      IsLeft = true;
    }

    private Either(TR right) => Right = right;

    public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

    public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);

    public Either<TL, TR> ToEither(TL left) => new Either<TL, TR>(left);

    public Either<TL, TR> ToEither(TR right) => new Either<TL, TR>(right);
  }
}
