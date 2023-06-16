using MovieRecommender.Models;

namespace MovieRecommender.Interfaces
{
    public interface ITmdbAPIContext
    {
        public Task<IEnumerable<Movie>> SearchMoviesByTitleAsync(string title);
        public Task<MovieDetail> GetMovieByIdAsync(int id);
        public Task<MovieResultsModel> GetMovieRecommendationsWithSameGenres(IEnumerable<Genre> genres, int page);
        public Task<IEnumerable<Actor>> GetCastByMovieIdAsync(int id);
        //public Task<IEnumerable<Genre>> GetGenresListAsync();
        //public Task<string> GetGenreNameAsync(int id);
    }
}
