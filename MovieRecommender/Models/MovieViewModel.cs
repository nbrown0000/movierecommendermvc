using Newtonsoft.Json;

namespace MovieRecommender.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PosterPath { get; set; }
        public string? Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genres { get; set; }
    }
}
