using System;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class UpdateTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public UpdateTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, Type)> DeserializationData => new TheoryData<(string, Type)>
    {
      (@"{""update_id"":1,""message"":{}}", typeof(Update)),
      (@"{""message"":{}}", typeof(MessageUpdate)),
      (@"{""edited_message"":{}}", typeof(EditedMessageUpdate)),
      (@"{""channel_post"":{}}", typeof(ChannelPostUpdate)),
      (@"{""edited_channel_post"":{}}", typeof(EditedChannelPostUpdate)),
      (@"{""inline_query"":{}}", typeof(InlineQueryUpdate)),
      (@"{""chosen_inline_result"":{}}", typeof(ChosenInlineResultUpdate)),
      (@"{""callback_query"":{}}", typeof(CallbackQueryUpdate)),
      (@"{""shipping_query"":{}}", typeof(ShippingQueryUpdate)),
      (@"{""pre_checkout_query"":{}}", typeof(PreCheckoutQueryUpdate)),
      (@"{""poll"":{""type"":""regular""}}", typeof(PollUpdate)),
      (@"{""poll_answer"":{}}", typeof(PollAnswerUpdate))
    };

    [Theory(DisplayName = "Update deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void UpdateDeserializesCorrectly((string, Type) tuple)
    {
      var (value, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<Update>(value));
    }
  }
}