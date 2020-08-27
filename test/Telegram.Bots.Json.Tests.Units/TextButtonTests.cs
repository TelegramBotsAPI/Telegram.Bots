using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class TextButtonTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public TextButtonTests(Serializer serializer) => _serializer = serializer;

    [Fact(DisplayName = "Serialization uses Text property")]
    public void SerializationUsesTextProperty() =>
      Assert.Equal(@"""Test""", _serializer.Serialize(new TextButton("Test")));
  }
}
