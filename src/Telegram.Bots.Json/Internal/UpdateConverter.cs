using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static UpdateSchema;

  internal sealed class UpdateConverter : JsonConverter
  {
    public override bool CanWrite => false;

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) =>
      throw new NotImplementedException();

    public override object? ReadJson(
      JsonReader reader,
      Type objectType,
      object? existingValue,
      JsonSerializer serializer)
    {
      var data = JObject.Load(reader);

      if (data.Type == JTokenType.Null) return null;

      return data.Properties().Single(property => property.Name != Id).Name switch
      {
        Message => Get<MessageUpdate>(),
        EditedMessage => Get<EditedMessageUpdate>(),
        ChannelPost => Get<ChannelPostUpdate>(),
        EditedChannelPost => Get<EditedChannelPostUpdate>(),
        InlineQuery => Get<InlineQueryUpdate>(),
        ChosenInlineResult => Get<ChosenInlineResultUpdate>(),
        CallbackQuery => Get<CallbackQueryUpdate>(),
        ShippingQuery => Get<ShippingQueryUpdate>(),
        PreCheckoutQuery => Get<PreCheckoutQueryUpdate>(),
        Poll => Get<PollUpdate>(),
        PollAnswer => Get<PollAnswerUpdate>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(Update);
  }

  internal static class UpdateSchema
  {
    public const string Id = "update_id";
    public const string Message = "message";
    public const string EditedMessage = "edited_message";
    public const string ChannelPost = "channel_post";
    public const string EditedChannelPost = "edited_channel_post";
    public const string InlineQuery = "inline_query";
    public const string ChosenInlineResult = "chosen_inline_result";
    public const string CallbackQuery = "callback_query";
    public const string ShippingQuery = "shipping_query";
    public const string PreCheckoutQuery = "pre_checkout_query";
    public const string Poll = "poll";
    public const string PollAnswer = "poll_answer";
  }
}
