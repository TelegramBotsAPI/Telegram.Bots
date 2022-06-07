// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bots.Requests;
using Telegram.Bots.Requests.Games;
using Telegram.Bots.Requests.Inline;
using Telegram.Bots.Requests.Payments;
using Telegram.Bots.Requests.Stickers;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Games;
using Telegram.Bots.Types.Inline;
using Telegram.Bots.Types.Passport;
using EditCaption = Telegram.Bots.Requests.Inline.EditCaption;
using EditLiveLocation = Telegram.Bots.Requests.Inline.EditLiveLocation;
using EditReplyMarkup = Telegram.Bots.Requests.Inline.EditReplyMarkup;
using EditText = Telegram.Bots.Requests.Inline.EditText;
using GetGameHighScores = Telegram.Bots.Requests.Games.Inline.GetGameHighScores;
using SetGameScore = Telegram.Bots.Requests.Games.Inline.SetGameScore;
using StopLiveLocation = Telegram.Bots.Requests.Inline.StopLiveLocation;

namespace Telegram.Bots.Json.Internal
{
  using Data = Dictionary<string, string>;

  internal sealed class ContractResolver : DefaultContractResolver
  {
    private static readonly IReadOnlyDictionary<Type, IReadOnlyDictionary<string, string>> Map =
      new Dictionary<Type, IReadOnlyDictionary<string, string>>
      {
        {typeof(Animation), new Data {{"name", "file_name"}}},
        {typeof(Audio), new Data {{"name", "file_name"}}},
        {typeof(Video), new Data {{"name", "file_name"}}},
        {typeof(GameCallbackQuery), new Data {{"short_name", "game_short_name"}}},
        {typeof(InlineMessageCallbackQuery), new Data {{"message_id", "inline_message_id"}}},
        {
          typeof(InlineGameCallbackQuery),
          new Data {{"message_id", "inline_message_id"}, {"short_name", "game_short_name"}}
        },
        {typeof(ChatInfo), new Data {{"pinned", "pinned_message"}}},
        {typeof(Document), new Data {{"name", "file_name"}}},
        {
          typeof(File), new Data
            {{"id", "file_id"}, {"unique_id", "file_unique_id"}, {"size", "file_size"}}
        },
        {typeof(FileInfo), new Data {{"path", "file_path"}}},
        {
          typeof(KeyboardMarkup),
          new Data {{"resize", "resize_keyboard"}, {"one_time", "one_time_keyboard"}}
        },
        {typeof(InlineKeyboardMarkup), new Data {{"keyboard", "inline_keyboard"}}},
        {typeof(CallbackDataButton), new Data {{"data", "callback_data"}}},
        {typeof(SwitchInlineQueryButton), new Data {{"query", "switch_inline_query"}}},
        {
          typeof(SwitchInlineQueryCurrentChatButton),
          new Data {{"query", "switch_inline_query_current_chat"}}
        },
        {typeof(CallbackGameButton), new Data {{"game", "callback_game"}}},
        {typeof(Game), new Data {{"photo_set", "photo"}}},
        {typeof(ChosenInlineResult), new Data {{"message_id", "inline_message_id"}}},
        {typeof(ReplaceableResult), new Data {{"content", "input_message_content"}}},
        {typeof(InlineArticle), new Data {{"thumb", "thumb_url"}}},
        {typeof(InlineAudio<string>), new Data {{"audio", "audio_file_id"}}},
        {typeof(InlineAudio<Uri>), new Data {{"audio", "audio_url"}}},
        {typeof(InlineAudio), new Data {{"duration", "audio_duration"}}},
        {typeof(InlineContact), new Data {{"thumb", "thumb_url"}}},
        {typeof(InlineDocument<string>), new Data {{"document", "document_file_id"}}},
        {typeof(InlineDocument<Uri>), new Data {{"document", "document_url"}}},
        {typeof(InlineDocument), new Data {{"thumb", "thumb_url"}}},
        {typeof(InlineGame), new Data {{"short_name", "game_short_name"}}},
        {typeof(InlineGif<string>), new Data {{"gif", "gif_file_id"}}},
        {typeof(InlineGif<Uri>), new Data {{"gif", "gif_url"}}},
        {
          typeof(InlineGif), new Data
          {
            {"width", "gif_width"}, {"height", "gif_height"},
            {"duration", "gif_duration"}, {"thumb", "thumb_url"}
          }
        },
        {typeof(InlineLocation), new Data {{"thumb", "thumb_url"}}},
        {typeof(InlineMpeg4Gif<string>), new Data {{"mpeg4", "mpeg4_file_id"}}},
        {typeof(InlineMpeg4Gif<Uri>), new Data {{"mpeg4", "mpeg4_url"}}},
        {
          typeof(InlineMpeg4Gif), new Data
          {
            {"width", "mpeg4_width"}, {"height", "mpeg4_height"},
            {"duration", "mpeg4_duration"}, {"thumb", "thumb_url"}
          }
        },
        {typeof(InlinePhoto<string>), new Data {{"photo", "photo_file_id"}}},
        {typeof(InlinePhoto<Uri>), new Data {{"photo", "photo_url"}}},
        {
          typeof(InlinePhoto), new Data
            {{"width", "photo_width"}, {"height", "photo_height"}, {"thumb", "thumb_url"}}
        },
        {typeof(InlineSticker<string>), new Data {{"sticker", "sticker_file_id"}}},
        {typeof(InlineVenue), new Data {{"thumb", "thumb_url"}}},
        {typeof(InlineVideo<string>), new Data {{"video", "video_file_id"}}},
        {typeof(InlineVideo<Uri>), new Data {{"video", "video_url"}}},
        {
          typeof(InlineVideo),
          new Data
          {
            {"width", "video_width"}, {"height", "video_height"},
            {"duration", "video_duration"}, {"thumb", "thumb_url"}
          }
        },
        {typeof(InlineVoice<string>), new Data {{"voice", "voice_file_id"}}},
        {typeof(InlineVoice<Uri>), new Data {{"voice", "voice_url"}}},
        {typeof(InlineVoice), new Data {{"duration", "voice_duration"}}},
        {typeof(TextContent), new Data {{"text", "message_text"}}},
        {typeof(MessageId), new Data {{"id", "message_id"}}},
        {typeof(Message), new Data {{"id", "message_id"}}},
        {typeof(NewChatMembersMessage), new Data {{"members", "new_chat_members"}}},
        {typeof(LeftChatMemberMessage), new Data {{"member", "left_chat_member"}}},
        {typeof(NewChatTitleMessage), new Data {{"title", "new_chat_title"}}},
        {typeof(NewChatPhotoMessage), new Data {{"photo_set", "new_chat_photo"}}},
        {typeof(PhotoMessage), new Data {{"photo_set", "photo"}}},
        {typeof(PinnedMessage), new Data {{"pinned", "pinned_message"}}},
        {typeof(DeleteChatPhotoMessage), new Data {{"deleted", "delete_chat_photo"}}},
        {typeof(GroupChatCreatedMessage), new Data {{"created", "group_chat_created"}}},
        {
          typeof(SupergroupChatCreatedMessage),
          new Data {{"created", "supergroup_chat_created"}}
        },
        {typeof(ChannelChatCreatedMessage), new Data {{"created", "channel_chat_created"}}},
        {
          typeof(AutoDeleteTimerChangedMessage),
          new Data {{"auto_delete_time", "message_auto_delete_time"}}
        },
        {typeof(MigrateToChatMessage), new Data {{"chat_id", "migrate_to_chat_id"}}},
        {typeof(MigrateFromChatMessage), new Data {{"chat_id", "migrate_from_chat_id"}}},
        {typeof(SuccessfulPaymentMessage), new Data {{"payment", "successful_payment"}}},
        {typeof(ConnectedWebsiteMessage), new Data {{"website", "connected_website"}}},
        {typeof(VideoChatScheduledMessage), new Data {{"scheduled", "video_chat_scheduled"}}},
        {typeof(VoiceChatStartedMessage), new Data {{"started", "voice_chat_started"}}},
        {typeof(VoiceChatEndedMessage), new Data {{"ended", "voice_chat_ended"}}},
        {
          typeof(VoiceChatParticipantsInvitedMessage),
          new Data {{"participants_invited", "voice_chat_participants_invited"}}
        },
        {
          typeof(PassportFile),
          new Data
          {
            {"id", "file_id"}, {"unique_id", "file_unique_id"},
            {"size", "file_size"}, {"date", "file_date"}
          }
        },
        {
          typeof(DataFieldError), new Data {{"name", "field_name"}, {"hash", "data_hash"}}
        },
        {typeof(DocumentError), new Data {{"hash", "file_hash"}}},
        {typeof(DocumentsError), new Data {{"hashes", "file_hashes"}}},
        {typeof(UnspecifiedError), new Data {{"hash", "element_hash"}}},
        {typeof(Update), new Data {{"id", "update_id"}}},
        {typeof(MessageUpdate), new Data {{"data", "message"}}},
        {typeof(EditedMessageUpdate), new Data {{"data", "edited_message"}}},
        {typeof(ChannelPostUpdate), new Data {{"data", "channel_post"}}},
        {typeof(EditedChannelPostUpdate), new Data {{"data", "edited_channel_post"}}},
        {typeof(InlineQueryUpdate), new Data {{"data", "inline_query"}}},
        {typeof(ChosenInlineResultUpdate), new Data {{"data", "chosen_inline_result"}}},
        {typeof(CallbackQueryUpdate), new Data {{"data", "callback_query"}}},
        {typeof(ShippingQueryUpdate), new Data {{"data", "shipping_query"}}},
        {typeof(PreCheckoutQueryUpdate), new Data {{"data", "pre_checkout_query"}}},
        {typeof(PollUpdate), new Data {{"data", "poll"}}},
        {typeof(PollAnswerUpdate), new Data {{"data", "poll_answer"}}},
        {typeof(MyChatMemberUpdate), new Data {{"data", "my_chat_member"}}},
        {typeof(ChatMemberUpdate), new Data {{"data", "chat_member"}}},
        {typeof(ChatJoinRequestUpdate), new Data {{"data", "chat_join_request"}}},
        {typeof(UserProfilePhotos), new Data {{"photo_sets", "photos"}}},
        {typeof(AnswerCallbackQuery), new Data {{"query_id", "callback_query_id"}}},
        {typeof(EditCaption), new Data {{"message_id", "inline_message_id"}}},
        {typeof(EditLiveLocation), new Data {{"message_id", "inline_message_id"}}},
        {typeof(EditMedia<string>), new Data {{"message_id", "inline_message_id"}}},
        {typeof(EditMedia<Uri>), new Data {{"message_id", "inline_message_id"}}},
        {typeof(EditReplyMarkup), new Data {{"message_id", "inline_message_id"}}},
        {typeof(EditText), new Data {{"message_id", "inline_message_id"}}},
        {typeof(GetFile), new Data {{"id", "file_id"}}},
        {typeof(StopLiveLocation), new Data {{"message_id", "inline_message_id"}}},
        {typeof(AnswerInlineQuery), new Data {{"query_id", "inline_query_id"}}},
        {typeof(GetGameHighScores), new Data {{"message_id", "inline_message_id"}}},
        {typeof(SendGame), new Data {{"short_name", "game_short_name"}}},
        {typeof(SetGameScoreBase), new Data {{"disable_edit", "disable_edit_message"}}},
        {typeof(SetGameScore), new Data {{"message_id", "inline_message_id"}}},
        {typeof(AnswerPreCheckoutQuery), new Data {{"query_id", "pre_checkout_query_id"}}},
        {typeof(AnswerShippingQuery), new Data {{"query_id", "shipping_query_id"}}},
        {typeof(SendInvoice), new Data {{"photo", "photo_url"}}},
        {typeof(AddStickerToSet<string>), new Data {{"sticker", "png_sticker"}}},
        {typeof(AddStickerToSet<Uri>), new Data {{"sticker", "png_sticker"}}},
        {typeof(AddStickerToSet<InputFile>), new Data {{"sticker", "png_sticker"}}},
        {typeof(AddAnimatedStickerToSet<InputFile>), new Data {{"sticker", "tgs_sticker"}}},
        {typeof(AddVideoStickerToSet<InputFile>), new Data {{"sticker", "webm_sticker"}}},
        {typeof(CreateNewStickerSet<string>), new Data {{"sticker", "png_sticker"}}},
        {typeof(CreateNewStickerSet<Uri>), new Data {{"sticker", "png_sticker"}}},
        {typeof(CreateNewStickerSet<InputFile>), new Data {{"sticker", "png_sticker"}}},
        {
          typeof(CreateNewAnimatedStickerSet<InputFile>), new Data {{"sticker", "tgs_sticker"}}
        },
        {
          typeof(CreateNewVideoStickerSetViaFile<InputFile>), new Data {{"sticker", "webm_sticker"}}
        },
        {typeof(UploadStickerFile), new Data {{"sticker", "png_sticker"}}}
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
