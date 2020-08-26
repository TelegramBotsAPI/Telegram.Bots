using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using Data = Dictionary<string, string>;

  internal sealed class ContractResolver : DefaultContractResolver
  {
    private static readonly IReadOnlyDictionary<Type, IReadOnlyDictionary<string, string>> Map =
      new Dictionary<Type, IReadOnlyDictionary<string, string>>
      {
        { typeof(Animation), new Data { { "name", "file_name" } } },
        { typeof(GameCallbackQuery), new Data { { "short_name", "game_short_name" } } },
        {
          typeof(InlineMessageCallbackQuery), new Data { { "message_id", "inline_message_id" } }
        },
        {
          typeof(InlineGameCallbackQuery),
          new Data { { "message_id", "inline_message_id" }, { "short_name", "game_short_name" } }
        },
        { typeof(ChatInfo), new Data { { "pinned", "pinned_message" } } },
        { typeof(Document), new Data { { "name", "file_name" } } },
        {
          typeof(File),
          new Data
          {
            { "id", "file_id" }, { "unique_id", "file_unique_id" }, { "size", "file_size" }
          }
        },
        { typeof(FileInfo), new Data { { "path", "file_path" } } }
      };

    protected override JsonProperty CreateProperty(
      MemberInfo member,
      MemberSerialization memberSerialization)
    {
      var property = base.CreateProperty(member, memberSerialization);

      if (property.DeclaringType != null && Map.TryGetValue(property.DeclaringType, out var info) &&
          property.PropertyName != null && info.TryGetValue(property.PropertyName, out var name))
        property.PropertyName = name;

      return property;
    }
  }
}
