// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright © 2020 Aman Agnihotri

using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bots.Requests;
using Telegram.Bots.Requests.Games;
using Telegram.Bots.Requests.Inline;
using Telegram.Bots.Requests.Payments;
using Telegram.Bots.Requests.Stickers;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Games;
using Telegram.Bots.Types.Inline;
using Telegram.Bots.Types.Passport;
using Telegram.Bots.Types.Payments;
using Telegram.Bots.Types.Stickers;
using Xunit;
using GetInlineGameHighScores = Telegram.Bots.Requests.Games.Inline.GetGameHighScores;
using SetInlineGameScore = Telegram.Bots.Requests.Games.Inline.SetGameScore;
using static Telegram.Bots.Types.Inline.DocumentMimeType;
using static Telegram.Bots.Types.Inline.VideoMimeType;
using EditCaption = Telegram.Bots.Requests.Inline.EditCaption;
using EditLiveLocation = Telegram.Bots.Requests.Inline.EditLiveLocation;
using EditMediaViaCache = Telegram.Bots.Requests.Inline.EditMediaViaCache;
using EditMediaViaUrl = Telegram.Bots.Requests.Inline.EditMediaViaUrl;
using EditReplyMarkup = Telegram.Bots.Requests.Inline.EditReplyMarkup;
using EditText = Telegram.Bots.Requests.Inline.EditText;
using FileInfo = Telegram.Bots.Types.FileInfo;
using StopLiveLocation = Telegram.Bots.Requests.Inline.StopLiveLocation;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class ContractResolverTests : IClassFixture<Serializer>
  {
    private static readonly InputFile File = Stream.Null;
    private static readonly Uri Uri = new Uri("https://example.com");

    private readonly Serializer _serializer;

    public ContractResolverTests(Serializer serializer) => _serializer = serializer;

    public static TheoryData<(string, object)> SerializationData => new TheoryData<(string, object)>
    {
      (@"""file_name"":""", new Animation { Name = "" }),
      (@"""game_short_name"":""", new GameCallbackQuery { ShortName = "" }),
      (@"""inline_message_id"":""", new InlineMessageCallbackQuery { MessageId = "" }),
      (@"""inline_message_id"":""", new InlineGameCallbackQuery { MessageId = "" }),
      (@"""game_short_name"":""", new InlineGameCallbackQuery { ShortName = "" }),
      (@"""pinned_message"":{", new ChatInfo { Pinned = new TextMessage { Text = "" } }),
      (@"""file_name"":""", new Document { Name = "" }),
      (@"""file_id"":""", new Audio { Id = "" }),
      (@"""file_unique_id"":""", new Photo { UniqueId = "" }),
      (@"""file_size"":1", new Video { Size = 1 }),
      (@"""file_path"":""", new FileInfo { Path = "" }),
      (@"""resize_keyboard"":true", new KeyboardMarkup(null!) { Resize = true }),
      (@"""one_time_keyboard"":true", new KeyboardMarkup(null!) { OneTime = true }),
      (@"""inline_keyboard"":[", new InlineKeyboardMarkup(new List<InlineButton[]>())),
      (@"""callback_data"":""", new CallbackDataButton("", "")),
      (@"""switch_inline_query"":""", new SwitchInlineQueryButton("", "")),
      (@"""switch_inline_query_current_chat"":""", new SwitchInlineQueryCurrentChatButton("", "")),
      (@"""callback_game"":{", new CallbackGameButton("")),
      (@"""photo"":[", new Game { PhotoSet = new List<Photo>() }),
      (@"""inline_message_id"":""", new ChosenInlineResult { MessageId = "" }),
      (@"""input_message_content"":{", new InlineArticle("", "") { Content = new TextContent("") }),
      (@"""thumb_url"":""", new InlineArticle("", "") { Thumb = Uri }),
      (@"""audio_file_id"":""", new InlineCachedAudio("", "")),
      (@"""audio_url"":""", new InlineAudio("", "", Uri)),
      (@"""audio_duration"":10", new InlineAudio("", "", Uri) { Duration = 10 }),
      (@"""thumb_url"":""", new InlineContact("", "", "") { Thumb = Uri }),
      (@"""document_file_id"":""", new InlineCachedDocument("", "", "")),
      (@"""document_url"":""", new InlineDocument("", "", Uri, Pdf)),
      (@"""thumb_url"":""", new InlineDocument("", "", Uri, Zip) { Thumb = Uri }),
      (@"""game_short_name"":""", new InlineGame("", "")),
      (@"""gif_file_id"":""", new InlineCachedGif("", "")),
      (@"""gif_url"":""", new InlineGif("", Uri, Uri)),
      (@"""gif_width"":1", new InlineGif("", Uri, Uri) { Width = 1 }),
      (@"""gif_height"":1", new InlineGif("", Uri, Uri) { Height = 1 }),
      (@"""gif_duration"":1", new InlineGif("", Uri, Uri) { Duration = 1 }),
      (@"""thumb_url"":""", new InlineGif("", Uri, Uri)),
      (@"""thumb_url"":""", new InlineLocation("", "", 1, 1) { Thumb = Uri }),
      (@"""mpeg4_file_id"":""", new InlineCachedMpeg4Gif("", "")),
      (@"""mpeg4_url"":""", new InlineMpeg4Gif("", Uri, Uri)),
      (@"""mpeg4_width"":1", new InlineMpeg4Gif("", Uri, Uri) { Width = 1 }),
      (@"""mpeg4_height"":1", new InlineMpeg4Gif("", Uri, Uri) { Height = 1 }),
      (@"""mpeg4_duration"":1", new InlineMpeg4Gif("", Uri, Uri) { Duration = 1 }),
      (@"""thumb_url"":""", new InlineMpeg4Gif("", Uri, Uri)),
      (@"""photo_file_id"":""", new InlineCachedPhoto("", "")),
      (@"""photo_url"":""", new InlinePhoto("", Uri, Uri)),
      (@"""thumb_url"":""", new InlinePhoto("", Uri, Uri)),
      (@"""photo_width"":1", new InlinePhoto("", Uri, Uri) { Width = 1 }),
      (@"""photo_height"":1", new InlinePhoto("", Uri, Uri) { Height = 1 }),
      (@"""sticker_file_id"":""", new InlineCachedSticker("", "")),
      (@"""thumb_url"":""", new InlineVenue("", "", "", 1, 1) { Thumb = Uri }),
      (@"""video_file_id"":""", new InlineCachedVideo("", "", "")),
      (@"""video_url"":""", new InlineVideo("", "", Uri, Html, Uri)),
      (@"""thumb_url"":""", new InlineVideo("", "", Uri, Html, Uri)),
      (@"""video_width"":1", new InlineVideo("", "", Uri, Html, Uri) { Width = 1 }),
      (@"""video_height"":1", new InlineVideo("", "", Uri, Html, Uri) { Height = 1 }),
      (@"""video_duration"":1", new InlineVideo("", "", Uri, Html, Uri) { Duration = 1 }),
      (@"""voice_file_id"":""", new InlineCachedVoice("", "", "")),
      (@"""voice_url"":""", new InlineVoice("", "", Uri)),
      (@"""voice_duration"":10", new InlineVoice("", "", Uri) { Duration = 10 }),
      (@"""message_text"":""", new TextContent("")),
      (@"""message_id"":1", new TextMessage { Id = 1 }),
      (@"""animation"":{", new AnimationMessage { Animation = new Animation() }),
      (@"""venue"":{", new VenueMessage { Venue = new Venue() }),
      (@"""text"":""Test""", new TextMessage { Text = "Test" }),
      (@"""audio"":{", new AudioMessage { Audio = new Audio() }),
      (@"""document"":{", new DocumentMessage { Document = new Document() }),
      (@"""photo"":[", new PhotoMessage { PhotoSet = new List<Photo>() }),
      (@"""sticker"":{", new StickerMessage { Sticker = new Sticker() }),
      (@"""video"":{", new VideoMessage { Video = new Video() }),
      (@"""video_note"":{", new VideoNoteMessage { VideoNote = new VideoNote() }),
      (@"""voice"":{", new VoiceMessage { Voice = new Voice() }),
      (@"""contact"":{", new ContactMessage { Contact = new Contact() }),
      (@"""dice"":{", new DiceMessage { Dice = new Dice() }),
      (@"""game"":{", new GameMessage { Game = new Game() }),
      (@"""poll"":{", new PollMessage { Poll = new RegularPoll() }),
      (@"""location"":{", new LocationMessage { Location = new Location() }),
      (@"""new_chat_members"":[", new NewChatMembersMessage { Members = new List<User>() }),
      (@"""left_chat_member"":{", new LeftChatMemberMessage { Member = new User() }),
      (@"""new_chat_title"":""""", new NewChatTitleMessage { Title = "" }),
      (@"""new_chat_photo"":[", new NewChatPhotoMessage { PhotoSet = new List<Photo>() }),
      (@"""delete_chat_photo"":true", new DeleteChatPhotoMessage { Deleted = true }),
      (@"""group_chat_created"":true", new GroupChatCreatedMessage { Created = true }),
      (@"""supergroup_chat_created"":true", new SupergroupChatCreatedMessage { Created = true }),
      (@"""channel_chat_created"":true", new ChannelChatCreatedMessage { Created = true }),
      (@"""migrate_to_chat_id"":1", new MigrateToChatMessage { ChatId = 1 }),
      (@"""migrate_from_chat_id"":1", new MigrateFromChatMessage { ChatId = 1 }),
      (@"""pinned_message"":{", new PinnedMessage { Pinned = new TextMessage() }),
      (@"""invoice"":{", new InvoiceMessage { Invoice = new Invoice() }),
      (@"""successful_payment"":{",
        new SuccessfulPaymentMessage { Payment = new SuccessfulPayment() }),
      (@"""connected_website"":""", new ConnectedWebsiteMessage { Website = Uri }),
      (@"""passport_data"":{", new PassportDataMessage { PassportData = new PassportData() }),
      (@"""file_id"":""", new PassportFile { Id = "" }),
      (@"""file_unique_id"":""", new PassportFile { UniqueId = "" }),
      (@"""file_size"":1", new PassportFile { Size = 1 }),
      (@"""file_date"":0", new PassportFile { Date = DateTime.UnixEpoch }),
      (@"""field_name"":""", new DataFieldError { Name = "" }),
      (@"""data_hash"":""", new DataFieldError { Hash = "" }),
      (@"""element_hash"":""", new UnspecifiedError { Hash = "" }),
      (@"""file_hash"":""", new FrontSideError { Hash = "" }),
      (@"""file_hashes"":[", new FilesError { Hashes = new List<string>() }),
      (@"""update_id"":1", new MessageUpdate { Id = 1, Data = new TextMessage() }),
      (@"""message"":{", new MessageUpdate { Data = new TextMessage() }),
      (@"""edited_message"":{", new EditedMessageUpdate { Data = new TextMessage() }),
      (@"""channel_post"":{", new ChannelPostUpdate { Data = new TextMessage() }),
      (@"""edited_channel_post"":{", new EditedChannelPostUpdate { Data = new TextMessage() }),
      (@"""inline_query"":{", new InlineQueryUpdate { Data = new InlineQuery() }),
      (@"""chosen_inline_result"":{",
        new ChosenInlineResultUpdate { Data = new ChosenInlineResult() }),
      (@"""callback_query"":{", new CallbackQueryUpdate { Data = new MessageCallbackQuery() }),
      (@"""shipping_query"":{", new ShippingQueryUpdate { Data = new ShippingQuery() }),
      (@"""pre_checkout_query"":{", new PreCheckoutQueryUpdate { Data = new PreCheckoutQuery() }),
      (@"""poll"":{", new PollUpdate { Data = new RegularPoll() }),
      (@"""poll_answer"":{", new PollAnswerUpdate { Data = new PollAnswer() }),
      (@"""photos"":[", new UserProfilePhotos { PhotoSets = new List<Photo[]>() }),
      (@"""callback_query_id"":""", new AnswerCallbackQuery("", "")),
      (@"""inline_message_id"":""", new EditCaption("")),
      (@"""inline_message_id"":""", new EditLiveLocation("", 0, 0)),
      (@"""inline_message_id"":""", new EditMediaViaCache("", new CachedPhoto(""))),
      (@"""inline_message_id"":""", new EditMediaViaUrl("", new PhotoUrl(Uri))),
      (@"""inline_message_id"":""", new EditLiveLocation("", 0, 0)),
      (@"""inline_message_id"":""", new EditReplyMarkup("")),
      (@"""inline_message_id"":""", new EditText("", "")),
      (@"""inline_message_id"":""", new StopLiveLocation("")),
      (@"""inline_query_id"":""", new AnswerInlineQuery("", new List<InlineResult>())),
      (@"""inline_message_id"":""", new GetInlineGameHighScores("", 1)),
      (@"""game_short_name"":""", new SendGame(1, "")),
      (@"""inline_message_id"":""", new SetInlineGameScore("", 1, 1)),
      (@"""disable_edit_message"":true", new SetGameScore(1, 1, 1, 1) { DisableEdit = true }),
      (@"""pre_checkout_query_id"":""", new AnswerPreCheckoutQuery("", "")),
      (@"""shipping_query_id"":""", new AnswerShippingQuery("", "")),
      (@"""photo_url"":""",
        new SendInvoice(1, "", "", "", "", "", "", new LabeledPrice[1]) { Photo = Uri }),
      (@"""png_sticker"":""", new AddStickerToSetViaCache(1, "", "", "")),
      (@"""png_sticker"":""", new AddStickerToSetViaUrl(1, "", "", Uri)),
      (@"""png_sticker"":""attach://", new AddStickerToSetViaFile(1, "", "", File)),
      (@"""tgs_sticker"":""attach://", new AddAnimatedStickerToSetViaFile(1, "", "", File)),
      (@"""png_sticker"":""", new CreateNewStickerSetViaCache(0, "", "", "", "")),
      (@"""png_sticker"":""", new CreateNewStickerSetViaUrl(0, "", "", "", Uri)),
      (@"""png_sticker"":""attach://", new CreateNewStickerSetViaFile(0, "", "", "", File)),
      (@"""tgs_sticker"":""attach://", new CreateNewAnimatedStickerSetViaFile(0, "", "", "", File)),
      (@"""png_sticker"":""", new UploadStickerFile(1, Stream.Null))
    };

    [Theory(DisplayName = "ContractResolver resolves properties correctly")]
    [MemberData(nameof(SerializationData))]
    public void ContractResolverResolvesPropertiesCorrectly((string, object) tuple)
    {
      var (value, data) = tuple;

      Assert.Contains(value, _serializer.Serialize(data), StringComparison.Ordinal);
    }
  }
}
