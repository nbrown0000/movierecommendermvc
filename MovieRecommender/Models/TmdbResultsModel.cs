namespace MovieRecommender.Models
{
    public class TmdbResultsModel
    {
        public int Page { get; set; }
        public IEnumerable<object> Results { get; set; }
        public int Total_Pages { get; set; }
        public int Total_Results { get; set; }
    }
}
