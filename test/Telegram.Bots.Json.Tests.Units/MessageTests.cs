using System;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class MessageTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public MessageTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, Type)> DeserializationData => new TheoryData<(string, Type)>
    {
      (@"{""message_id"":1,""text"":""""}", typeof(Message)),
      (@"{""text"":""""}", typeof(TextMessage))
    };

    [Theory(DisplayName = "Message deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void MessageDeserializesCorrectly((string, Type) tuple)
    {
      var (data, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<Message>(data));
    }
  }
}
