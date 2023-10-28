using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using ToptikVedio.Services.Client;


namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task DownloadFromPexels(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {     
        switch(update.Text)
        {
               case "Rasm📸":
                 await botClient.SendTextMessageAsync(update.Chat.Id,
                 "Rasm nomini kiriting:",
                 cancellationToken: cancellationToken);
               break;
               case "Фото📸":
                 await botClient.SendTextMessageAsync(update.Chat.Id,
                 "Введите имя изображения:",
                 cancellationToken: cancellationToken);
               break;
               case "Photo📸":
                 await botClient.SendTextMessageAsync(update.Chat.Id,
                 "Enter a name for the image:",
                 cancellationToken: cancellationToken);
                break; 
        }  
        isPhotos = true;
        isVedios = false;
        checkTrue = false;
    }

    public async Task ResponIfNull(
        ITelegramBotClient botClient,
        Message update,
        CancellationToken cancellationToken)
    {
        await botClient.SendTextMessageAsync(update.Chat.Id,
            "Bunday Photo Topilmadi!",
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

        if(result.TotalResults == 0) 
        {
            await ResponIfNull(botClient, update, cancellationToken);
        }

        foreach (var item in result.Photos)
        {
            await botClient.SendPhotoAsync(
            chatId: update.Chat.Id,
            photo: InputFile.FromUri(new Uri(item.Src.Large2X)));
        }
    }
}
