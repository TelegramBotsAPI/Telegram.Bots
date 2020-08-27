using System;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class InlineButtonTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public InlineButtonTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, Type)> DeserializationData => new TheoryData<(string, Type)>
    {
      (@"{""url"":""https://example.com""}", typeof(UrlButton)),
      (@"{""login_url"":{}}", typeof(LoginUrlButton)),
      (@"{""callback_data"":""""}", typeof(CallbackDataButton)),
      (@"{""switch_inline_query"":""""}", typeof(SwitchInlineQueryButton)),
      (@"{""switch_inline_query_current_chat"":""""}",
        typeof(SwitchInlineQueryCurrentChatButton)),
      (@"{""callback_game"":{}}", typeof(CallbackGameButton)),
      (@"{""pay"":true}", typeof(PayButton))
    };

    [Theory(DisplayName = "InlineButton deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void InlineButtonDeserializesCorrectly((string, Type) tuple)
    {
      var (value, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<InlineButton>(value));
    }
  }
}
