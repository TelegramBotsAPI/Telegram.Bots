// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Json.Internal;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Types;
using static MessageSchema;

internal sealed class MessageConverter : JsonConverter
{
  private static readonly HashSet<string> MessageTypes = new()
  {
    Text,
    MessageSchema.Animation,
    MessageSchema.Audio,
    MessageSchema.Document,
    MessageSchema.Photo,
    Sticker,
    MessageSchema.Video,
    MessageSchema.VideoNote,
    MessageSchema.Voice,
    MessageSchema.Contact,
    MessageSchema.Dice,
    Game,
    MessageSchema.Poll,
    MessageSchema.Venue,
    MessageSchema.Location,
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
    MessageSchema.PinnedMessage,
    Invoice,
    SuccessfulPayment,
    ConnectedWebsite,
    PassportData,
    MessageSchema.ProximityAlertTriggered,
    MessageSchema.VideoChatScheduled,
    MessageSchema.VideoChatStarted,
    MessageSchema.VideoChatEnded,
    MessageSchema.VideoChatParticipantsInvited,
    MessageSchema.WebAppData
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
    JObject data = JObject.Load(reader);

    if (data.Type == JTokenType.Null)
    {
      return null;
    }

    HashSet<string> types = data.Properties()
      .Where(property => MessageTypes.Contains(property.Name))
      .Select(property => property.Name)
      .ToHashSet();

    if (types.Count == 0)
    {
      return null;
    }

    if (types.Contains(MessageSchema.Animation))
    {
      return Get<AnimationMessage>();
    }

    if (types.Contains(MessageSchema.Venue))
    {
      return Get<VenueMessage>();
    }

    return types.Single() switch
    {
      Text => Get<TextMessage>(),
      MessageSchema.Audio => Get<AudioMessage>(),
      MessageSchema.Document => Get<DocumentMessage>(),
      MessageSchema.Photo => Get<PhotoMessage>(),
      Sticker => Get<StickerMessage>(),
      MessageSchema.Video => Get<VideoMessage>(),
      MessageSchema.VideoNote => Get<VideoNoteMessage>(),
      MessageSchema.Voice => Get<VoiceMessage>(),
      MessageSchema.Contact => Get<ContactMessage>(),
      MessageSchema.Dice => Get<DiceMessage>(),
      Game => Get<GameMessage>(),
      MessageSchema.Poll => Get<PollMessage>(),
      MessageSchema.Location => Get<LocationMessage>(),
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
      MessageSchema.PinnedMessage => Get<PinnedMessage>(),
      Invoice => Get<InvoiceMessage>(),
      SuccessfulPayment => Get<SuccessfulPaymentMessage>(),
      ConnectedWebsite => Get<ConnectedWebsiteMessage>(),
      PassportData => Get<PassportDataMessage>(),
      MessageSchema.ProximityAlertTriggered =>
        Get<ProximityAlertTriggeredMessage>(),
      MessageSchema.VideoChatScheduled => Get<VideoChatScheduledMessage>(),
      MessageSchema.VideoChatStarted => Get<VideoChatStartedMessage>(),
      MessageSchema.VideoChatEnded => Get<VideoChatEndedMessage>(),
      MessageSchema.VideoChatParticipantsInvited =>
        Get<VideoChatParticipantsInvitedMessage>(),
      MessageSchema.WebAppData => Get<WebAppDataMessage>(),
      _ => null
    };

    T Get<T>() => data.ToObject<T>(serializer)!;
  }

  public override bool CanConvert(Type objectType)
  {
    return objectType == typeof(Message) ||
           objectType == typeof(MediaGroupMessage) ||
           objectType == typeof(MediaMessage) ||
           objectType == typeof(CaptionableMessage);
  }
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

  public const string AutoDeleteTimerChanged =
    "message_auto_delete_timer_changed";

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
  public const string VideoChatEnded = "video_chat_ended";

  public const string VideoChatParticipantsInvited =
    "video_chat_participants_invited";

  public const string WebAppData = "web_app_data";
}
