// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using Telegram.Bots.Types;

namespace Telegram.Bots.Requests
{
  public abstract record SendContact<TChatId> : IRequest<LocationMessage>,
    IChatTargetable<TChatId>, INotifiable, IReplyable, IMarkupable
  {
    public TChatId ChatId { get; }

    public string PhoneNumber { get; }

    public string FirstName { get; }

    public string? LastName { get; init; }

    public string? Vcard { get; init; }

    public bool? DisableNotification { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method { get; } = "sendContact";

    protected SendContact(TChatId chatId, string phoneNumber, string firstName)
    {
      ChatId = chatId;
      PhoneNumber = phoneNumber;
      FirstName = firstName;
    }
  }

  public sealed record SendContact : SendContact<long>
  {
    public SendContact(long chatId, string phoneNumber, string firstName) :
      base(chatId, phoneNumber, firstName) { }
  }

  namespace Usernames
  {
    public sealed record SendContact : SendContact<string>
    {
      public SendContact(string username, string phoneNumber, string firstName) :
        base(username, phoneNumber, firstName) { }
    }
  }
}
