using System;
using System.Collections.Generic;
using Telegram.Bots.Types;
using Telegram.Bots.Types.Games;
using Telegram.Bots.Types.Inline;
using Telegram.Bots.Types.Passport;
using Telegram.Bots.Types.Payments;
using Telegram.Bots.Types.Stickers;
using Xunit;

namespace Telegram.Bots.Json.Tests.Units
{
  public sealed class ContractResolverTests : IClassFixture<Serializer>
  {
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
      (@"""inline_keyboard"":[", new InlineKeyboardMarkup(new List<InlineKeyboardButton[]>())),
      (@"""callback_data"":""", new CallbackDataButton("", "")),
      (@"""switch_inline_query"":""", new SwitchInlineQueryButton("", "")),
      (@"""switch_inline_query_current_chat"":""",
        new SwitchInlineQueryCurrentChatButton("", "")),
      (@"""callback_game"":{", new CallbackGameButton("")),
      (@"""photo"":[", new Game { PhotoSet = new List<Photo>() }),
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
      (@"""reply_markup"":{",
        new ReplyMarkupMessage { ReplyMarkup = new InlineKeyboardMarkup(null!) }),
      (@"""file_id"":""", new PassportFile { Id = "" }),
      (@"""file_unique_id"":""", new PassportFile { UniqueId = "" }),
      (@"""file_size"":1", new PassportFile { Size = 1 }),
      (@"""file_date"":1", new PassportFile { Date = 1 }),
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
      (@"""photos"":[", new UserProfilePhotos { PhotoSets = new List<Photo[]>() })
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
