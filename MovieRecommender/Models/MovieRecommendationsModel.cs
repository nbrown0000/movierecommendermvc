namespace MovieRecommender.Models
{
    public class MovieRecommendationsModel
    {
        public int MovieId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
