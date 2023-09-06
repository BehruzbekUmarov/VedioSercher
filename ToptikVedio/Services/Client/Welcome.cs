using System.Text.Json;
using System.Text.Json.Serialization;
using Telegram.Bot.Requests;

namespace ToptikVedio.Services.Client;

public class Welcome
{
    [JsonPropertyName("page")]
        public long Page { get; set; }

        [JsonPropertyName("per_page")]
        public long PerPage { get; set; }

        [JsonPropertyName("photos")]
        public List<Photo> Photos { get; set; }

        [JsonPropertyName("total_results")]
        public long TotalResults { get; set; }

        [JsonPropertyName("next_page")]
        public Uri NextPage { get; set; }
}
public class Photo
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("width")]
    public long Width { get; set; }

    [JsonPropertyName("height")]
    public long Height { get; set; }

    [JsonPropertyName("url")]
    public Uri Url { get; set; }

    [JsonPropertyName("photographer")]
    public string Photographer { get; set; }

    [JsonPropertyName("photographer_url")]
    public Uri PhotographerUrl { get; set; }

    [JsonPropertyName("photographer_id")]
    public long PhotographerId { get; set; }

    [JsonPropertyName("avg_color")]
    public string AvgColor { get; set; }

    [JsonPropertyName("src")]
    public Src Src { get; set; }

    [JsonPropertyName("liked")]
    public bool Liked { get; set; }

    [JsonPropertyName("alt")]
    public string Alt { get; set; }
}

public class Src
{
    [JsonPropertyName("original")]
    public Uri Original { get; set; }

    [JsonPropertyName("large2x")]
    public Uri Large2X { get; set; }

    [JsonPropertyName("large")]
    public Uri Large { get; set; }

    [JsonPropertyName("medium")]
    public Uri Medium { get; set; }

    [JsonPropertyName("small")]
    public Uri Small { get; set; }

    [JsonPropertyName("portrait")]
    public Uri Portrait { get; set; }

    [JsonPropertyName("landscape")]
    public Uri Landscape { get; set; }

    [JsonPropertyName("tiny")]
    public Uri Tiny { get; set; }
}
