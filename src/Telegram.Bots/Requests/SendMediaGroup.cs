// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020-2022 Aman Agnihotri

namespace Telegram.Bots.Requests
{
  using System.Collections.Generic;
  using System.Linq;
  using Types;
  using IGroupableMediaList =
    System.Collections.Generic.IEnumerable<Types.IGroupableMedia>;

  public abstract record SendMediaGroup<TChatId>(
    TChatId ChatId,
    IEnumerable<IGroupableMedia> Media) :
    IRequest<IReadOnlyList<MediaGroupMessage>>, IChatTargetable<TChatId>,
    INotifiable, IProtectable, IReplyable, IUploadable
  {
    public bool? DisableNotification { get; init; }

    public bool? ProtectContent { get; init; }

    public int? ReplyToMessageId { get; init; }

    public bool? AllowSendingWithoutReply { get; init; }

    public string Method => "sendMediaGroup";

    public IEnumerable<InputFile?> GetFiles()
    {
      return Media
        .OfType<IUploadableMedia>()
        .SelectMany(media => media.GetFiles());
    }
  }

  public sealed record SendMediaGroup(
    long ChatId,
    IGroupableMediaList Media) : SendMediaGroup<long>(ChatId, Media);

  namespace Usernames
  {
    public sealed record SendMediaGroup(
      string ChatId,
      IGroupableMediaList Media) : SendMediaGroup<string>(ChatId, Media);
  }
}
