// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2021 Aman Agnihotri

using System;
using System.Collections.Generic;
using Telegram.Bots.Types.Games;
using Telegram.Bots.Types.Passport;
using Telegram.Bots.Types.Payments;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Types
{
  public abstract record Message
  {
    public int Id { get; init; }

    public User? From { get; init; }

    public Chat? SenderChat { get; init; }

    public DateTime Date { get; init; } = DateTime.UnixEpoch;

    public Chat Chat { get; init; } = null!;

    public User? ForwardFrom { get; init; }

    public Chat? ForwardFromChat { get; init; }

    public int? ForwardFromMessageId { get; init; }

    public string? ForwardSignature { get; init; }

    public string? ForwardSenderName { get; init; }

    public DateTime? ForwardDate { get; init; }

    public Message? ReplyToMessage { get; init; }

    public User? ViaBot { get; init; }

    public DateTime? EditDate { get; init; }

    public string? AuthorSignature { get; init; }

    public InlineKeyboardMarkup? ReplyMarkup { get; init; }

    public bool IsAutomaticallyForwarded => From?.Id == 777000;

    public bool IsFromAnonymousGroupAdmin => From?.Id == 1087968824;
  }

  public abstract record CaptionableMessage : Message
  {
    public string? Caption { get; init; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; init; }
  }

  public abstract record MediaMessage : CaptionableMessage { }

  public abstract record MediaGroupMessage : MediaMessage
  {
    public string? MediaGroupId { get; init; }
  }

  public abstract record ServiceMessage : Message { }

  public sealed record TextMessage : Message
  {
    public string Text { get; init; } = null!;

    public IReadOnlyList<MessageEntity>? Entities { get; init; }
  }

  public sealed record AnimationMessage : MediaMessage
  {
    public Animation Animation { get; init; } = null!;
  }

  public sealed record AudioMessage : MediaMessage
  {
    public Audio Audio { get; init; } = null!;
  }

  public sealed record DocumentMessage : MediaMessage
  {
    public Document Document { get; init; } = null!;
  }

  public sealed record PhotoMessage : MediaGroupMessage
  {
    public IReadOnlyList<Photo> PhotoSet { get; init; } = null!;
  }

  public sealed record StickerMessage : Message
  {
    public Sticker Sticker { get; init; } = null!;
  }

  public sealed record VideoMessage : MediaGroupMessage
  {
    public Video Video { get; init; } = null!;
  }

  public sealed record VideoNoteMessage : Message
  {
    public VideoNote VideoNote { get; init; } = null!;
  }

  public sealed record VoiceMessage : CaptionableMessage
  {
    public Voice Voice { get; init; } = null!;
  }

  public sealed record ContactMessage : Message
  {
    public Contact Contact { get; init; } = null!;
  }

  public sealed record DiceMessage : Message
  {
    public Dice Dice { get; init; } = null!;
  }

  public sealed record GameMessage : Message
  {
    public Game Game { get; init; } = null!;
  }

  public sealed record PollMessage : Message
  {
    public Poll Poll { get; init; } = null!;
  }

  public sealed record VenueMessage : Message
  {
    public Venue Venue { get; init; } = null!;
  }

  public sealed record LocationMessage : Message
  {
    public Location Location { get; init; } = null!;
  }

  public sealed record NewChatMembersMessage : Message
  {
    public IReadOnlyList<User> Members { get; init; } = null!;
  }

  public sealed record LeftChatMemberMessage : Message
  {
    public User Member { get; init; } = null!;
  }

  public sealed record NewChatTitleMessage : Message
  {
    public string Title { get; init; } = null!;
  }

  public sealed record NewChatPhotoMessage : Message
  {
    public IReadOnlyList<Photo> PhotoSet { get; init; } = null!;
  }

  public sealed record DeleteChatPhotoMessage : ServiceMessage
  {
    public bool Deleted { get; init; }
  }

  public sealed record GroupChatCreatedMessage : ServiceMessage
  {
    public bool Created { get; init; }
  }

  public sealed record SupergroupChatCreatedMessage : ServiceMessage
  {
    public bool Created { get; init; }
  }

  public sealed record ChannelChatCreatedMessage : ServiceMessage
  {
    public bool Created { get; init; }
  }

  public sealed record AutoDeleteTimerChangedMessage : ServiceMessage
  {
    public int AutoDeleteTime { get; init; }
  }

  public sealed record MigrateToChatMessage : Message
  {
    public long ChatId { get; init; }
  }

  public sealed record MigrateFromChatMessage : Message
  {
    public long ChatId { get; init; }
  }

  public sealed record PinnedMessage : Message
  {
    public Message Pinned { get; init; } = null!;
  }

  public sealed record InvoiceMessage : Message
  {
    public Invoice Invoice { get; init; } = null!;
  }

  public sealed record SuccessfulPaymentMessage : ServiceMessage
  {
    public SuccessfulPayment Payment { get; init; } = null!;
  }

  public sealed record ConnectedWebsiteMessage : Message
  {
    public Uri Website { get; init; } = null!;
  }

  public sealed record PassportDataMessage : Message
  {
    public PassportData PassportData { get; init; } = null!;
  }

  public sealed record ProximityAlertTriggeredMessage : ServiceMessage
  {
    public ProximityAlertTriggered ProximityAlertTriggered { get; init; } = null!;
  }

  public sealed record VoiceChatStartedMessage : ServiceMessage { }

  public sealed record VoiceChatEndedMessage : ServiceMessage
  {
    public int Duration { get; init; }
  }

  public sealed record VoiceChatParticipantsInvitedMessage : ServiceMessage
  {
    public IReadOnlyList<User>? Users { get; init; }
  }
}
