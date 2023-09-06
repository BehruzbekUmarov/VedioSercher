using System.Text.Json;

namespace ToptikVedio.Services.Handlers;

public partial class BotUpdateHandler : HttpClient
{
    public async Task<string> GetDownloadLink(string url)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers =
            {
                { "X-RapidAPI-Key", "a2bb5e5a37mshc03765de782efbbp10f64ejsnd7995df478ff" },
                { "X-RapidAPI-Host", "pdf-to-text-converter.p.rapidapi.com" },
            },
        };

        using var response = await SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        var searchResult = JsonSerializer.Deserialize<PutResult>(body)
            ?? throw new ArgumentNullException();

        return searchResult.ToString();
    }
    public class PutResult
    {

    }
}
