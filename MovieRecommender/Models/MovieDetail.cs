using Newtonsoft.Json;

namespace MovieRecommender.Models
{
    public class MovieDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("genres")]
        public List<Genre>? Genres { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("vote_average")]
        public double Rating { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

    }
}
