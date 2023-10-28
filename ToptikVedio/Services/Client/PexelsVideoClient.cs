using System.Text.Json.Serialization;

namespace ToptikVedio.Services.Client
{
    public class PexelsVideoClient
    {
        [JsonPropertyName("page")]
        public long Page { get; set; }

        [JsonPropertyName("per_page")]
        public long PerPage { get; set; }

        [JsonPropertyName("videos")]
        public List<Video> Videos { get; set; }

        [JsonPropertyName("total_results")]
        public long TotalResults { get; set; }

        [JsonPropertyName("next_page")]
        public string NextPage { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Video
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("full_res")]
        public object FullRes { get; set; }

        [JsonPropertyName("tags")]
        public List<object> Tags { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("avg_color")]
        public object AvgColor { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("video_files")]
        public List<VideoFile> VideoFiles { get; set; }

        [JsonPropertyName("video_pictures")]
        public List<VideoPicture> VideoPictures { get; set; }
    }

    public class User
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class VideoFile
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("quality")]
        public string Quality { get; set; }

        [JsonPropertyName("file_type")]
        public string FileType { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("fps")]
        public double Fps { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
    public class VideoPicture
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nr")]
        public long Nr { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }
    }
}
