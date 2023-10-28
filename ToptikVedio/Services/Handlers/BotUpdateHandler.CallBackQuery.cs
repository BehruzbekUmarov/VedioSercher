using Telegram.Bot.Types;
using Telegram.Bot;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task CallbackQueryHandler(
        ITelegramBotClient bot,
        CallbackQuery? message,
        CancellationToken cancellation)
    {
        {
            var resMessage = string.Empty;

            switch (message?.Data)
            {
                case "uz":
                    await MenuBotUz(bot, message, cancellation);
                    resMessage = "O'zbek tilini tanladingiz";
                    break;

                case "ru":
                    await MenuBotRu(bot, message, cancellation);
                    resMessage = "Вы выбрали Русский язык";
                    break;
                case "eng":
                    await MenuBotEng(bot, message, cancellation);
                    resMessage = "You chose English language";
                    break;
                case "Sozlamalar⚙️":
                    await SettingUz(bot, message, cancellation);
                    break;
                case "Hастройки⚙️":
                    await SettingRu(bot, message, cancellation);
                    break;
                case "Settings⚙️":
                    await SettingEng(bot, message, cancellation);
                    break;
            }

            await bot.AnswerCallbackQueryAsync(
                message?.Id!,
                resMessage,
                cancellationToken: cancellation);
        }
    }
}
