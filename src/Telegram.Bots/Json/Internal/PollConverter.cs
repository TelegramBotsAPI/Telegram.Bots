// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Json.Internal;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Types;
using static PollSchema;

internal sealed class PollConverter : JsonConverter
{
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

    string type = data.Properties()
      .Single(property => property.Name == PollSchema.Type).Value
      .ToString();

    return type switch
    {
      Regular => Get<RegularPoll>(),
      Quiz => Get<QuizPoll>(),
      _ => null
    };

    T Get<T>() => data.ToObject<T>(serializer)!;
  }

  public override bool CanConvert(Type objectType)
  {
    return objectType == typeof(Poll);
  }
}

internal static class PollSchema
{
  public const string Type = "type";
  public const string Regular = "regular";
  public const string Quiz = "quiz";
}
