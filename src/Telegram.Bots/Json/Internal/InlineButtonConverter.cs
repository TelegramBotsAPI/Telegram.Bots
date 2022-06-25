// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Json.Internal;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Types;
using static InlineButtonSchema;

internal sealed class InlineButtonConverter : JsonConverter
{
  private static readonly HashSet<string> ButtonTypes = new()
  {
    Url,
    InlineButtonSchema.LoginUrl,
    CallbackData,
    SwitchInlineQuery,
    SwitchQueryCurrentChat,
    CallbackGame,
    Pay
  };

  public override bool CanWrite => false;

  public override void WriteJson(
    JsonWriter writer,
    object? value,
    JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }

  public override object? ReadJson(
    JsonReader reader,
    Type objectType,
    object? existingValue,
    JsonSerializer serializer)
  {
    JObject? data = JObject.Load(reader);

    if (data.Type == JTokenType.Null)
    {
      return null;
    }

    string name = data.Properties()
      .Single(property => ButtonTypes.Contains(property.Name)).Name;

    return name switch
    {
      Url => Get<UrlButton>(),
      InlineButtonSchema.LoginUrl => Get<LoginUrlButton>(),
      CallbackData => Get<CallbackDataButton>(),
      SwitchInlineQuery => Get<SwitchInlineQueryButton>(),
      SwitchQueryCurrentChat => Get<SwitchInlineQueryCurrentChatButton>(),
      CallbackGame => Get<CallbackGameButton>(),
      Pay => Get<PayButton>(),
      _ => null
    };

    T Get<T>() => data.ToObject<T>(serializer)!;
  }

  public override bool CanConvert(Type objectType)
  {
    return objectType == typeof(InlineButton);
  }
}

internal static class InlineButtonSchema
{
  public const string Url = "url";
  public const string LoginUrl = "login_url";
  public const string CallbackData = "callback_data";
  public const string SwitchInlineQuery = "switch_inline_query";

  public const string SwitchQueryCurrentChat =
    "switch_inline_query_current_chat";

  public const string CallbackGame = "callback_game";
  public const string Pay = "pay";
}
