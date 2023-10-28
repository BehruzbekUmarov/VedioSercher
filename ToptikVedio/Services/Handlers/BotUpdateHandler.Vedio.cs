using Telegram.Bot.Types;
using Telegram.Bot;
using ToptikVedio.Services.Client;
using System.Text.Json;
using Telegram.Bot.Types.ReplyMarkups;

namespace ToptikVedio.Services.Handlers
{
    public partial class BotUpdateHandler
    {
        public async Task DownloadLinkFromPexels(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
        {
            await botClient.SendTextMessageAsync(update.Chat.Id,
                 "Video nomini kiriting:\n" +
                 "Enter video title:\n" +
                 "Введите название видео:",
                cancellationToken: cancellationToken);
            isVedios = true;
            isPhotos = false;
            checkTrue = false;
        }
        public async Task SearchVideo(
            ITelegramBotClient botClient,
            Message update,
            CancellationToken cancellationToken)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_options.Value.BaseUri);

            client.DefaultRequestHeaders.Add("Authorization", _options.Value.ApiKey);

            var response = await client.GetAsync($"videos/search?query={update.Text}&per_page=20");

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PexelsVideoClient>(jsonString)
                ?? throw new ArgumentException();

            if(result.TotalResults == 0) 
        {
            await ResponIfNull(botClient, update, cancellationToken);
        }

            foreach (var video in result.Videos)
            {
                await botClient.SendVideoAsync(
                   chatId: update.Chat.Id,
                   video: InputFile.FromUri(video.VideoFiles.First().Link),
                   supportsStreaming: true,
                   cancellationToken: cancellationToken);
            }
        }
    }
}
