using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Games;
using Telegram.Bots.Types.Inline;
using Telegram.Bots.Types.Passport;

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
        { typeof(FileInfo), new Data { { "path", "file_path" } } },
        {
          typeof(KeyboardMarkup),
          new Data { { "resize", "resize_keyboard" }, { "one_time", "one_time_keyboard" } }
        },
        { typeof(InlineKeyboardMarkup), new Data { { "keyboard", "inline_keyboard" } } },
        { typeof(CallbackDataButton), new Data { { "data", "callback_data" } } },
        { typeof(SwitchInlineQueryButton), new Data { { "query", "switch_inline_query" } } },
        {
          typeof(SwitchInlineQueryCurrentChatButton),
          new Data { { "query", "switch_inline_query_current_chat" } }
        },
        { typeof(CallbackGameButton), new Data { { "game", "callback_game" } } },
        { typeof(Game), new Data { { "photo_set", "photo" } } },
        { typeof(ChosenInlineResult), new Data { { "message_id", "inline_message_id" } } },
        { typeof(TextContent), new Data { { "text", "message_text" } } },
        { typeof(Message), new Data { { "id", "message_id" } } },
        { typeof(NewChatMembersMessage), new Data { { "members", "new_chat_members" } } },
        { typeof(LeftChatMemberMessage), new Data { { "member", "left_chat_member" } } },
        { typeof(NewChatTitleMessage), new Data { { "title", "new_chat_title" } } },
        { typeof(NewChatPhotoMessage), new Data { { "photo_set", "new_chat_photo" } } },
        { typeof(PhotoMessage), new Data { { "photo_set", "photo" } } },
        { typeof(PinnedMessage), new Data { { "pinned", "pinned_message" } } },
        { typeof(DeleteChatPhotoMessage), new Data { { "deleted", "delete_chat_photo" } } },
        { typeof(GroupChatCreatedMessage), new Data { { "created", "group_chat_created" } } },
        {
          typeof(SupergroupChatCreatedMessage),
          new Data { { "created", "supergroup_chat_created" } }
        },
        { typeof(ChannelChatCreatedMessage), new Data { { "created", "channel_chat_created" } } },
        { typeof(MigrateToChatMessage), new Data { { "chat_id", "migrate_to_chat_id" } } },
        { typeof(MigrateFromChatMessage), new Data { { "chat_id", "migrate_from_chat_id" } } },
        { typeof(SuccessfulPaymentMessage), new Data { { "payment", "successful_payment" } } },
        { typeof(ConnectedWebsiteMessage), new Data { { "website", "connected_website" } } },
        {
          typeof(PassportFile),
          new Data
          {
            { "id", "file_id" },
            { "unique_id", "file_unique_id" },
            { "size", "file_size" },
            { "date", "file_date" }
          }
        },
        {
          typeof(DataFieldError), new Data { { "name", "field_name" }, { "hash", "data_hash" } }
        },
        { typeof(DocumentError), new Data { { "hash", "file_hash" } } },
        { typeof(DocumentsError), new Data { { "hashes", "file_hashes" } } },
        { typeof(UnspecifiedError), new Data { { "hash", "element_hash" } } },
        { typeof(Update), new Data { { "id", "update_id" } } },
        { typeof(MessageUpdate), new Data { { "data", "message" } } },
        { typeof(EditedMessageUpdate), new Data { { "data", "edited_message" } } },
        { typeof(ChannelPostUpdate), new Data { { "data", "channel_post" } } },
        { typeof(EditedChannelPostUpdate), new Data { { "data", "edited_channel_post" } } },
        { typeof(InlineQueryUpdate), new Data { { "data", "inline_query" } } },
        { typeof(ChosenInlineResultUpdate), new Data { { "data", "chosen_inline_result" } } },
        { typeof(CallbackQueryUpdate), new Data { { "data", "callback_query" } } },
        { typeof(ShippingQueryUpdate), new Data { { "data", "shipping_query" } } },
        { typeof(PreCheckoutQueryUpdate), new Data { { "data", "pre_checkout_query" } } },
        { typeof(PollUpdate), new Data { { "data", "poll" } } },
        { typeof(PollAnswerUpdate), new Data { { "data", "poll_answer" } } },
        { typeof(UserProfilePhotos), new Data { { "photo_sets", "photos" } } }
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
