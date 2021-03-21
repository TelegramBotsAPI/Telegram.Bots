// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using Telegram.Bots.Types;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class MessageTests : IClassFixture<Serializer>
  {
    private readonly Serializer _serializer;

    public MessageTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, Type)> DeserializationData => new()
    {
      (@"{""message_id"":1,""text"":""""}", typeof(Message)),
      (@"{""animation"":{},""document"":{}}", typeof(AnimationMessage)),
      (@"{""location"":{},""venue"":{}}", typeof(VenueMessage)),
      (@"{""text"":""""}", typeof(TextMessage)),
      (@"{""audio"":{}}", typeof(AudioMessage)),
      (@"{""document"":{}}", typeof(DocumentMessage)),
      (@"{""photo"":[]}", typeof(PhotoMessage)),
      (@"{""sticker"":{}}", typeof(StickerMessage)),
      (@"{""video"":{}}", typeof(VideoMessage)),
      (@"{""video_note"":{}}", typeof(VideoNoteMessage)),
      (@"{""voice"":{}}", typeof(VoiceMessage)),
      (@"{""contact"":{}}", typeof(ContactMessage)),
      (@"{""dice"":{}}", typeof(DiceMessage)),
      (@"{""game"":{}}", typeof(GameMessage)),
      (@"{""poll"":{""type"":""regular""}}", typeof(PollMessage)),
      (@"{""location"":{}}", typeof(LocationMessage)),
      (@"{""new_chat_members"":[]}", typeof(NewChatMembersMessage)),
      (@"{""left_chat_member"":{}}", typeof(LeftChatMemberMessage)),
      (@"{""new_chat_title"":""""}", typeof(NewChatTitleMessage)),
      (@"{""new_chat_photo"":[]}", typeof(NewChatPhotoMessage)),
      (@"{""delete_chat_photo"":true}", typeof(DeleteChatPhotoMessage)),
      (@"{""group_chat_created"":true}", typeof(GroupChatCreatedMessage)),
      (@"{""supergroup_chat_created"":true}", typeof(SupergroupChatCreatedMessage)),
      (@"{""channel_chat_created"":true}", typeof(ChannelChatCreatedMessage)),
      (@"{""message_auto_delete_timer_changed"":{}}", typeof(AutoDeleteTimerChangedMessage)),
      (@"{""migrate_to_chat_id"":1}", typeof(MigrateToChatMessage)),
      (@"{""migrate_from_chat_id"":1}", typeof(MigrateFromChatMessage)),
      (@"{""pinned_message"":{}}", typeof(PinnedMessage)),
      (@"{""invoice"":{}}", typeof(InvoiceMessage)),
      (@"{""successful_payment"":{}}", typeof(SuccessfulPaymentMessage)),
      (@"{""connected_website"":""""}", typeof(ConnectedWebsiteMessage)),
      (@"{""passport_data"":{}}", typeof(PassportDataMessage)),
      (@"{""proximity_alert_triggered"":{}}", typeof(ProximityAlertTriggeredMessage))
    };

    [Theory(DisplayName = "Message deserializes correctly")]
    [MemberData(nameof(DeserializationData))]
    public void MessageDeserializesCorrectly((string, Type) tuple)
    {
      var (data, type) = tuple;

      Assert.IsAssignableFrom(type, _serializer.Deserialize<Message>(data));
    }
  }
}
