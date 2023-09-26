using MovieRecommender.Models;

namespace MovieRecommender.Interfaces
{
    public interface ITmdbAPIContext
    {
        public Task<MovieSearchResults> SearchMoviesByTitleAsync(string title, int page);
        public Task<MovieDetail> GetMovieByIdAsync(int id);
        public Task<MovieRecommendationsModel> GetMovieRecommendationsWithSameGenres(IEnumerable<Genre> genres, int page);
        public Task<IEnumerable<Actor>> GetCastByMovieIdAsync(int id);
        //public Task<IEnumerable<Genre>> GetGenresListAsync();
        //public Task<string> GetGenreNameAsync(int id);
    }
}
