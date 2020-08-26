using System.Collections.Generic;

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

  public sealed class TextMessage : Message
  {
    public string Text { get; set; } = null!;

    public IReadOnlyList<MessageEntity>? Entities { get; set; }
  }
}
