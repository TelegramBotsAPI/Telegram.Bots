// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract class SendContact<TChatId> : IRequest<LocationMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public string PhoneNumber { get; }

    public string FirstName { get; }

    public string? LastName { get; set; }

    public string? Vcard { get; set; }

    public bool? DisableNotification { get; set; }

    public int? ReplyToMessageId { get; set; }

    public bool? AllowSendingWithoutReply { get; set; }

    public ReplyMarkup? ReplyMarkup { get; set; }

    public string Method { get; } = "sendContact";

    protected SendContact(TChatId chatId, string phoneNumber, string firstName)
    {
      ChatId = chatId;
      PhoneNumber = phoneNumber;
      FirstName = firstName;
    }
  }

  public sealed class SendContact : SendContact<long>
  {
    public SendContact(long chatId, string phoneNumber, string firstName) :
      base(chatId, phoneNumber, firstName) { }
  }

  namespace Usernames
  {
    public sealed class SendContact : SendContact<string>
    {
      public SendContact(string username, string phoneNumber, string firstName) :
        base(username, phoneNumber, firstName) { }
    }
  }
}
