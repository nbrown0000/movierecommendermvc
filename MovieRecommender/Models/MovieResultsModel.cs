namespace MovieRecommender.Models
{
    public class MovieResultsModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}
