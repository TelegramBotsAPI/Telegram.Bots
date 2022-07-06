// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using Types;

  public abstract record SendContact<TChatId>(
    TChatId ChatId,
    string PhoneNumber,
    string FirstName) : IRequest<LocationMessage>, IChatTargetable<TChatId>,
    INotifiable, IProtectable, IReplyable, IMarkupable
  {
    public string? LastName { get; init; }

    public string? Vcard { get; init; }

    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public ReplyMarkup? ReplyMarkup { get; init; }

    public string Method => "sendContact";
  }

  public sealed record SendContact(
    long ChatId,
    string PhoneNumber,
    string FirstName) : SendContact<long>(ChatId, PhoneNumber, FirstName);

  namespace Usernames
  {
    public sealed record SendContact(
      string ChatId,
      string PhoneNumber,
      string FirstName) : SendContact<string>(ChatId, PhoneNumber, FirstName);
  }
}
