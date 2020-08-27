using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static InlineKeyboardButtonSchema;

  internal sealed class InlineKeyboardButtonConverter : JsonConverter
  {
    private static readonly HashSet<string> ButtonTypes = new HashSet<string>
    {
      Url,
      LoginUrl,
      CallbackData,
      SwitchInlineQuery,
      SwitchQueryCurrentChat,
      CallbackGame,
      Pay
    };

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

      return data.Properties().Single(property => ButtonTypes.Contains(property.Name)).Name switch
      {
        Url => Get<UrlButton>(),
        LoginUrl => Get<LoginUrlButton>(),
        CallbackData => Get<CallbackDataButton>(),
        SwitchInlineQuery => Get<SwitchInlineQueryButton>(),
        SwitchQueryCurrentChat => Get<SwitchInlineQueryCurrentChatButton>(),
        CallbackGame => Get<CallbackGameButton>(),
        Pay => Get<PayButton>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(InlineKeyboardButton);
  }

  internal static class InlineKeyboardButtonSchema
  {
    public const string Url = "url";
    public const string LoginUrl = "login_url";
    public const string CallbackData = "callback_data";
    public const string SwitchInlineQuery = "switch_inline_query";
    public const string SwitchQueryCurrentChat = "switch_inline_query_current_chat";
    public const string CallbackGame = "callback_game";
    public const string Pay = "pay";
  }
}
