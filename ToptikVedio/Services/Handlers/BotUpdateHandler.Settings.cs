using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task SettingUz(
   ITelegramBotClient bot,
   CallbackQuery? message,
   CancellationToken cancellation)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Tilni o'zgartirsh" }
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage = await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Выберите нужный раздел",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellation);
    }

    public async Task SettingRu(
    ITelegramBotClient bot,
    CallbackQuery? message,
    CancellationToken cancellation)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
        {
            new KeyboardButton[] { "Изменить язык" }
        })
        {
            ResizeKeyboard = true
        };

        Message sentMessage = await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Выберите нужный раздел",
            replyMarkup: replyKeyboardMarkup,
            cancellationToken: cancellation);
    }

    public async Task SettingEng(
    ITelegramBotClient bot,
    CallbackQuery? message,
    CancellationToken cancellation)
    {
        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
            new []
            {
                new KeyboardButton("Change language")
            }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Choose needed section:",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }
}
