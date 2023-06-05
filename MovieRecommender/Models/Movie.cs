using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieRecommender.Models
{
    public class Movie
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

        [JsonProperty("genre_ids")]
        public List<int>? GenreIds { get; set; }
    }
}
