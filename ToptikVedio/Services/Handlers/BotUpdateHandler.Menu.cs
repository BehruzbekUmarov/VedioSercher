using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task MenuBotUz(
    ITelegramBotClient bot,
    CallbackQuery? message,
    CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
            new []
            {
                new KeyboardButton("Video🎥"),
                new KeyboardButton("Sozlamalar⚙️")
            },
            new []
            {
                new KeyboardButton("Photo📸")
            }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Kerakli bo'limni tanlang:",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }

    public async Task MenuBotRu(
        ITelegramBotClient bot,
        CallbackQuery? message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
            new []
            {
                new KeyboardButton("Видео🎥"),
                new KeyboardButton("Hастройки⚙️")
            },
            new []
            {
                new KeyboardButton("Фото📸")
            }
            })
        {
            ResizeKeyboard = true
        };

        await bot.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Выберите нужный раздел",
            replyMarkup: replyKeyboard,
            cancellationToken: cancellation
        );
    }

    public async Task MenuBotEng(
        ITelegramBotClient bot,
        CallbackQuery? message,
        CancellationToken cancellation)
    {

        var replyKeyboard = new ReplyKeyboardMarkup(
            new[]
            {
            new []
            {
                new KeyboardButton("Video🎥"),
                new KeyboardButton("Settings⚙️")
            },
            new []
            {
                new KeyboardButton("Photo📸")
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

    private IReplyMarkup? BotTaskButtonMenuUz()
    {
        var replyKeyboard = new ReplyKeyboardMarkup(
        new[]
        {
            new[]
            {
                new KeyboardButton("Tilni o'zgartirsh")
            }
        })
        {
            ResizeKeyboard = true
        };

        return replyKeyboard;
    }

    private IReplyMarkup? BotTaskButtonMenuRu()
    {
        var replyKeyboard = new ReplyKeyboardMarkup(
        new[]
        {
            new[]
            {
                new KeyboardButton("Изменить язык")
            }
        })
        {
            ResizeKeyboard = true
        };

        return replyKeyboard;
    }

    private IReplyMarkup? BotTaskButtonMenuEng()
    {
        var replyKeyboard = new ReplyKeyboardMarkup(
        new[]
        {
            new[]
            {
                new KeyboardButton("Change language")
            }
        })
        {
            ResizeKeyboard = true
        };

        return replyKeyboard;
    }
}
