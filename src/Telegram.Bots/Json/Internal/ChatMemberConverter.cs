// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static ChatMemberSchema;

  internal sealed class ChatMemberConverter : JsonConverter
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

      return data.Properties().Single(property => property.Name == Status).Value.ToString() switch
      {
        Creator => Get<Creator>(),
        Administrator => Get<Administrator>(),
        Member => Get<NormalMember>(),
        Restricted => Get<RestrictedMember>(),
        Left => Get<LeftMember>(),
        Kicked => Get<KickedMember>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(ChatMember);
  }

  internal static class ChatMemberSchema
  {
    public const string Status = "status";
    public const string Creator = "creator";
    public const string Administrator = "administrator";
    public const string Member = "member";
    public const string Restricted = "restricted";
    public const string Left = "left";
    public const string Kicked = "kicked";
  }
}
