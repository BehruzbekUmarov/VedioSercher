using Telegram.Bot.Types;
using Telegram.Bot;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task TextProcessing(
        ITelegramBotClient botClient,
        Message? update,
        CancellationToken cancellationToken,
        bool isEdited)
    {
        if (update is null)
            throw new ArgumentNullException(nameof(update));

        
        switch (update.Text)
        {

            case "/start" or "Tilni o'zgartirsh" or "Изменить язык" or "Change language":
                await LanguageHandler(botClient, update, cancellationToken);
                break;
            case "Video" or "Photo": 
                await DownloadFromPexels(botClient, update, cancellationToken);
                break;

        }

        if (update.ReplyToMessage is not null && update.ReplyToMessage.Text.Contains("nomini kiriting:"))
        {
            await SearchPhoto(botClient, update, cancellationToken);
        }

    }
}
