using Telegram.Bot.Types;
using Telegram.Bot;
namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool isStartTrue = true;
    private bool isPhotos = false;
    private bool isVedios = false ;
    private bool checkTrue = true;
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
            case "/start":
                if (isStartTrue)
                {
                    await botClient.SendTextMessageAsync(
                    update.Chat.Id,
                    $"Hello dears 👋👦 You can use this bot\n" +
                    $"to see vedios🎬 and photos📸 ");
                }
                await LanguageHandler(botClient, update, cancellationToken);
                break;
            case "Tilni o'zgartirsh"
            or "Изменить язык" or "Change language":
                await LanguageHandler(botClient, update, cancellationToken);
                break;
            case "Photo📸" or "Rasm📸"
            or "Фото📸":
                await DownloadFromPexels(botClient, update, cancellationToken);
                break;
            case "Video🎥" or "Video🎥"
            or "Видео🎥":
                await DownloadLinkFromPexels(botClient, update, cancellationToken);
                break;
            case "Sozlamalar⚙️":
                await botClient.SendTextMessageAsync(
                    update.Chat.Id,
                    $"Select needed section",
                    replyMarkup: BotTaskButtonMenuUz());
                break;
            case "Hастройки⚙️":
                await botClient.SendTextMessageAsync(
                    update.Chat.Id,
                    $"Выберите необходимый раздел",
                    replyMarkup: BotTaskButtonMenuRu());
                break;
            case "Settings⚙️":
                await botClient.SendTextMessageAsync(
                    update.Chat.Id,
                    $"Select needed section",
                    replyMarkup: BotTaskButtonMenuEng());
                break;
        }

        if (update.ReplyToMessage is not null)
        {
            if (isPhotos)
            {
                await SearchPhoto(botClient, update, cancellationToken);
            }
            else if (isVedios)
            {
                await SearchVideo(botClient, update, cancellationToken);
            }
        }
    }
}
