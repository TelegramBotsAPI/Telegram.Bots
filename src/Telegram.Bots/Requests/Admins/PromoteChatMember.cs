// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests.Admins
{
  public abstract record PromoteChatMember<TChatId>(
    TChatId ChatId,
    long UserId) : IRequest<bool>, IChatMemberTargetable<TChatId>
  {
    public bool? IsAnonymous { get; init; }

    public bool? CanManageChat { get; init; }

    public bool? CanChangeInfo { get; init; }

    public bool? CanPostMessages { get; init; }

    public bool? CanEditMessages { get; init; }

    public bool? CanDeleteMessages { get; init; }

    public bool? CanManageVideoChats { get; init; }

    public bool? CanInviteUsers { get; init; }

    public bool? CanRestrictMembers { get; init; }

    public bool? CanPinMessages { get; init; }

    public bool? CanPromoteMembers { get; init; }

    public bool? CanManageTopics { get; init; }

    public string Method => "promoteChatMember";
  }

  public sealed record PromoteChatMember(
    long ChatId,
    long UserId) : PromoteChatMember<long>(ChatId, UserId);

  namespace Usernames
  {
    public sealed record PromoteChatMember(
      string ChatId,
      long UserId) : PromoteChatMember<string>(ChatId, UserId);
  }
}
