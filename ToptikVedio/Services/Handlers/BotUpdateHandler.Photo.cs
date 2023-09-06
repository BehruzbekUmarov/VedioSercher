using System.Text.Json;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using ToptikVedio.Services.Client;
using System.Security.Cryptography.X509Certificates;
using ToptikVedio.Options;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task DownloadFromPexels(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Photo nomini kiriting:",
            cancellationToken: cancellationToken);
    }

    public async Task SearchPhoto(
        ITelegramBotClient botClient,
        Message update, 
        CancellationToken cancellationToken)
    {
        var client = new HttpClient();

        client.BaseAddress = new Uri(_options.Value.BaseUri);

        client.DefaultRequestHeaders.Add("Authorization", _options.Value.ApiKey);

        var response = await client.GetAsync($"v1/search?query={update.Text}&per_page=10");

        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Welcome>(jsonString)
            ?? throw new ArgumentException();

        //Directory.CreateDirectory(@"./Files");
        //var photoInfo = result.;

        await botClient.SendPhotoAsync(
            chatId: update.Chat.Id,
            photo: InputFile.FromUri(result.Photos[0].Src.Original));


        foreach (var item in result.Photos)
        {
            await botClient.SendPhotoAsync(
            chatId: update.Chat.Id,
            photo: InputFile.FromUri(item.Src.Original));
        }

    }
}
