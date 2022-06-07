// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bots.Types;

namespace Telegram.Bots.Json.Internal
{
  using static MessageSchema;

  internal sealed class MessageConverter : JsonConverter
  {
    private static readonly HashSet<string> MessageTypes = new()
    {
      Text,
      Animation,
      Audio,
      Document,
      Photo,
      Sticker,
      Video,
      VideoNote,
      Voice,
      Contact,
      Dice,
      Game,
      Poll,
      Venue,
      Location,
      NewChatMembers,
      LeftChatMember,
      NewChatTitle,
      NewChatPhoto,
      DeleteChatPhoto,
      GroupChatCreated,
      SupergroupChatCreated,
      ChannelChatCreated,
      AutoDeleteTimerChanged,
      MigrateToChatId,
      MigrateFromChatId,
      PinnedMessage,
      Invoice,
      SuccessfulPayment,
      ConnectedWebsite,
      PassportData,
      ProximityAlertTriggered,
      VideoChatScheduled,
      VideoChatStarted,
      VoiceChatEnded,
      VoiceChatParticipantsInvited
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

      var types = data.Properties().Where(property => MessageTypes.Contains(property.Name))
        .Select(property => property.Name).ToHashSet();

      if (types.Count == 0) return null;

      if (types.Contains(Animation)) return Get<AnimationMessage>();
      if (types.Contains(Venue)) return Get<VenueMessage>();

      return types.Single() switch
      {
        Text => Get<TextMessage>(),
        Audio => Get<AudioMessage>(),
        Document => Get<DocumentMessage>(),
        Photo => Get<PhotoMessage>(),
        Sticker => Get<StickerMessage>(),
        Video => Get<VideoMessage>(),
        VideoNote => Get<VideoNoteMessage>(),
        Voice => Get<VoiceMessage>(),
        Contact => Get<ContactMessage>(),
        Dice => Get<DiceMessage>(),
        Game => Get<GameMessage>(),
        Poll => Get<PollMessage>(),
        Location => Get<LocationMessage>(),
        NewChatMembers => Get<NewChatMembersMessage>(),
        LeftChatMember => Get<LeftChatMemberMessage>(),
        NewChatTitle => Get<NewChatTitleMessage>(),
        NewChatPhoto => Get<NewChatPhotoMessage>(),
        DeleteChatPhoto => Get<DeleteChatPhotoMessage>(),
        GroupChatCreated => Get<GroupChatCreatedMessage>(),
        SupergroupChatCreated => Get<SupergroupChatCreatedMessage>(),
        ChannelChatCreated => Get<ChannelChatCreatedMessage>(),
        AutoDeleteTimerChanged => Get<AutoDeleteTimerChangedMessage>(),
        MigrateToChatId => Get<MigrateToChatMessage>(),
        MigrateFromChatId => Get<MigrateFromChatMessage>(),
        PinnedMessage => Get<PinnedMessage>(),
        Invoice => Get<InvoiceMessage>(),
        SuccessfulPayment => Get<SuccessfulPaymentMessage>(),
        ConnectedWebsite => Get<ConnectedWebsiteMessage>(),
        PassportData => Get<PassportDataMessage>(),
        ProximityAlertTriggered => Get<ProximityAlertTriggeredMessage>(),
        VideoChatScheduled => Get<VideoChatScheduledMessage>(),
        VideoChatStarted => Get<VideoChatStartedMessage>(),
        VoiceChatEnded => Get<VoiceChatEndedMessage>(),
        VoiceChatParticipantsInvited => Get<VoiceChatParticipantsInvitedMessage>(),
        _ => null
      };

      T Get<T>() => data.ToObject<T>(serializer)!;
    }

    public override bool CanConvert(Type objectType) =>
      objectType == typeof(Message) ||
      objectType == typeof(MediaGroupMessage) ||
      objectType == typeof(MediaMessage) ||
      objectType == typeof(CaptionableMessage);
  }

  internal static class MessageSchema
  {
    public const string Text = "text";
    public const string Animation = "animation";
    public const string Audio = "audio";
    public const string Document = "document";
    public const string Photo = "photo";
    public const string Sticker = "sticker";
    public const string Video = "video";
    public const string VideoNote = "video_note";
    public const string Voice = "voice";
    public const string Contact = "contact";
    public const string Dice = "dice";
    public const string Game = "game";
    public const string Poll = "poll";
    public const string Venue = "venue";
    public const string Location = "location";
    public const string NewChatMembers = "new_chat_members";
    public const string LeftChatMember = "left_chat_member";
    public const string NewChatTitle = "new_chat_title";
    public const string NewChatPhoto = "new_chat_photo";
    public const string DeleteChatPhoto = "delete_chat_photo";
    public const string GroupChatCreated = "group_chat_created";
    public const string SupergroupChatCreated = "supergroup_chat_created";
    public const string ChannelChatCreated = "channel_chat_created";
    public const string AutoDeleteTimerChanged = "message_auto_delete_timer_changed";
    public const string MigrateToChatId = "migrate_to_chat_id";
    public const string MigrateFromChatId = "migrate_from_chat_id";
    public const string PinnedMessage = "pinned_message";
    public const string Invoice = "invoice";
    public const string SuccessfulPayment = "successful_payment";
    public const string ConnectedWebsite = "connected_website";
    public const string PassportData = "passport_data";
    public const string ProximityAlertTriggered = "proximity_alert_triggered";
    public const string VideoChatScheduled = "video_chat_scheduled";
    public const string VideoChatStarted = "video_chat_started";
    public const string VoiceChatEnded = "voice_chat_ended";
    public const string VoiceChatParticipantsInvited = "voice_chat_participants_invited";
  }
}
