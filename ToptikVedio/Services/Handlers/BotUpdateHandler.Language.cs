﻿using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task LanguageHandler(
        ITelegramBotClient bot,
        Message? message,
        CancellationToken cancellation)
    {
        var inlineKeyboard = new InlineKeyboardMarkup(
            new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Uz", callbackData:"uz"),
                    InlineKeyboardButton.WithCallbackData("Ru", callbackData:"ru"),
                    InlineKeyboardButton.WithCallbackData("Eng", callbackData:"eng")
                },
            });

        if (message is not null)
            await bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Tilni tanlang:\nВыберите язык:\nChoose language:",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellation
            );
        checkTrue = false;
    }
}
