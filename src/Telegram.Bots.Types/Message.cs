using System;
using System.Collections.Generic;
using Telegram.Bots.Types.Games;
using Telegram.Bots.Types.Passport;
using Telegram.Bots.Types.Payments;
using Telegram.Bots.Types.Stickers;

namespace Telegram.Bots.Types
{
  public abstract class Message
  {
    public int Id { get; set; }

    public User? From { get; set; }

    public long Date { get; set; }

    public Chat Chat { get; set; } = null!;

    public User? ForwardFrom { get; set; }

    public Chat? ForwardFromChat { get; set; }

    public int? ForwardFromMessageId { get; set; }

    public string? ForwardSignature { get; set; }

    public string? ForwardSenderName { get; set; }

    public long? ForwardDate { get; set; }

    public Message? ReplyToMessage { get; set; }

    public User? ViaBot { get; set; }

    public long? EditDate { get; set; }

    public string? AuthorSignature { get; set; }
  }

  public abstract class CaptionableMessage : Message
  {
    public string? Caption { get; set; }

    public IReadOnlyList<MessageEntity>? CaptionEntities { get; set; }
  }

  public abstract class InputMediaMessage : CaptionableMessage { }

  public abstract class InputMediaGroupMessage : InputMediaMessage
  {
    public string? MediaGroupId { get; set; }
  }

  public abstract class ServiceMessage : Message { }

  public sealed class TextMessage : Message
  {
    public string Text { get; set; } = null!;

    public IReadOnlyList<MessageEntity>? Entities { get; set; }
  }

  public sealed class AnimationMessage : InputMediaMessage
  {
    public Animation Animation { get; set; } = null!;
  }

  public sealed class AudioMessage : InputMediaMessage
  {
    public Audio Audio { get; set; } = null!;
  }

  public sealed class DocumentMessage : InputMediaMessage
  {
    public Document Document { get; set; } = null!;
  }

  public sealed class PhotoMessage : InputMediaGroupMessage
  {
    public IReadOnlyList<Photo> PhotoSet { get; set; } = null!;
  }

  public sealed class StickerMessage : Message
  {
    public Sticker Sticker { get; set; } = null!;
  }

  public sealed class VideoMessage : InputMediaGroupMessage
  {
    public Video Video { get; set; } = null!;
  }

  public sealed class VideoNoteMessage : Message
  {
    public VideoNote VideoNote { get; set; } = null!;
  }

  public sealed class VoiceMessage : CaptionableMessage
  {
    public Voice Voice { get; set; } = null!;
  }

  public sealed class ContactMessage : Message
  {
    public Contact Contact { get; set; } = null!;
  }

  public sealed class DiceMessage : Message
  {
    public Dice Dice { get; set; } = null!;
  }

  public sealed class GameMessage : Message
  {
    public Game Game { get; set; } = null!;
  }

  public sealed class PollMessage : Message
  {
    public Poll Poll { get; set; } = null!;
  }

  public sealed class VenueMessage : Message
  {
    public Venue Venue { get; set; } = null!;
  }

  public sealed class LocationMessage : Message
  {
    public Location Location { get; set; } = null!;
  }

  public sealed class NewChatMembersMessage : Message
  {
    public IReadOnlyList<User> Members { get; set; } = null!;
  }

  public sealed class LeftChatMemberMessage : Message
  {
    public User Member { get; set; } = null!;
  }

  public sealed class NewChatTitleMessage : Message
  {
    public string Title { get; set; } = null!;
  }

  public sealed class NewChatPhotoMessage : Message
  {
    public IReadOnlyList<Photo> PhotoSet { get; set; } = null!;
  }

  public sealed class DeleteChatPhotoMessage : ServiceMessage
  {
    public bool Deleted { get; set; }
  }

  public sealed class GroupChatCreatedMessage : ServiceMessage
  {
    public bool Created { get; set; }
  }

  public sealed class SupergroupChatCreatedMessage : ServiceMessage
  {
    public bool Created { get; set; }
  }

  public sealed class ChannelChatCreatedMessage : ServiceMessage
  {
    public bool Created { get; set; }
  }

  public sealed class MigrateToChatMessage : Message
  {
    public long ChatId { get; set; }
  }

  public sealed class MigrateFromChatMessage : Message
  {
    public long ChatId { get; set; }
  }

  public sealed class PinnedMessage : Message
  {
    public Message Pinned { get; set; } = null!;
  }

  public sealed class InvoiceMessage : Message
  {
    public Invoice Invoice { get; set; } = null!;
  }

  public sealed class SuccessfulPaymentMessage : ServiceMessage
  {
    public SuccessfulPayment Payment { get; set; } = null!;
  }

  public sealed class ConnectedWebsiteMessage : Message
  {
    public Uri Website { get; set; } = null!;
  }

  public sealed class PassportDataMessage : Message
  {
    public PassportData PassportData { get; set; } = null!;
  }

  public sealed class ReplyMarkupMessage : Message
  {
    public InlineKeyboardMarkup ReplyMarkup { get; set; } = null!;
  }
}
