using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Games;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class ContractResolverTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public ContractResolverTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, object)> SerializationData => new TheoryData<(string, object)>
    {
      (@"""file_name"":""", new Animation { Name = "" }),
      (@"""game_short_name"":""", new GameCallbackQuery { ShortName = "" }),
      (@"""inline_message_id"":""", new InlineMessageCallbackQuery { MessageId = "" }),
      (@"""inline_message_id"":""", new InlineGameCallbackQuery { MessageId = "" }),
      (@"""game_short_name"":""", new InlineGameCallbackQuery { ShortName = "" }),
      (@"""pinned_message"":{", new ChatInfo { Pinned = new TextMessage { Text = "" } }),
      (@"""file_name"":""", new Document { Name = "" }),
      (@"""file_id"":""", new Audio { Id = "" }),
      (@"""file_unique_id"":""", new Photo { UniqueId = "" }),
      (@"""file_size"":1", new Video { Size = 1 }),
      (@"""file_path"":""", new FileInfo { Path = "" }),
      (@"""resize_keyboard"":true", new KeyboardMarkup(null!) { Resize = true }),
      (@"""one_time_keyboard"":true", new KeyboardMarkup(null!) { OneTime = true }),
      (@"""inline_keyboard"":[", new InlineKeyboardMarkup(new List<InlineKeyboardButton[]>())),
      (@"""callback_data"":""", new CallbackDataButton("", "")),
      (@"""switch_inline_query"":""", new SwitchInlineQueryButton("", "")),
      (@"""switch_inline_query_current_chat"":""",
        new SwitchInlineQueryCurrentChatButton("", "")),
      (@"""callback_game"":{", new CallbackGameButton("")),
      (@"""photo"":[", new Game { PhotoSet = new List<Photo>() }),
      (@"""message_id"":1", new TextMessage { Id = 1 }),
      (@"""photos"":[", new UserProfilePhotos { PhotoSets = new List<Photo[]>() })
    };

    [Theory(DisplayName = "ContractResolver resolves properties correctly")]
    [MemberData(nameof(SerializationData))]
    public void ContractResolverResolvesPropertiesCorrectly((string, object) tuple)
    {
      var (value, data) = tuple;

      Assert.Contains(value, _serializer.Serialize(data), StringComparison.Ordinal);
    }
  }
}
