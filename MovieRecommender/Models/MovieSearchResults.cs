namespace MovieRecommender.Models
{
    public class MovieSearchResults
    {
        public string SearchTitle { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
