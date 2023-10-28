using Microsoft.Extensions.Options;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Polling;
using ToptikVedio.Options;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandler> _logger;
    IOptions<Option> _options;
    public BotUpdateHandler(ILogger<BotUpdateHandler> logger, 
        IOptions<Option> options)
    {
        _logger = logger;
        _options = options;
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Error while polling for updates");
        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Incoming message\n From: {update.Message?.From?.Username}\n" +
            $"Text: {update.Message?.Text}");
        var handlers = update.Type switch
        {
            UpdateType.Message => MessageHandlerAsync(botClient, update.Message, cancellationToken),
            UpdateType.InlineQuery => throw new NotImplementedException(),
            UpdateType.ChosenInlineResult => throw new NotImplementedException(),
            UpdateType.CallbackQuery => CallbackQueryHandler(botClient, update.CallbackQuery, cancellationToken),
            UpdateType.EditedMessage => MessageHandlerAsync(botClient, update.EditedMessage, cancellationToken, true),
            _ => throw new ArgumentOutOfRangeException()
        };

        try
        {
            await handlers;
        }
        catch (Exception exception)
        {
            await HandlePollingErrorAsync(botClient, exception, cancellationToken);
        }
    }
}
