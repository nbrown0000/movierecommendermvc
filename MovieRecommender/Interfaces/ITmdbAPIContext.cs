using MovieRecommender.Models;

namespace MovieRecommender.Interfaces
{
    public interface ITmdbAPIContext
    {
        public Task<IEnumerable<Movie>> SearchMoviesByTitleAsync(string title);
        public Task<MovieDetail> GetMovieByIdAsync(int id);
        public Task<IEnumerable<Actor>> GetCastByMovieIdAsync(int id);
        public Task<IEnumerable<Movie>> GetRecommendationsMatchingGenresAndLeadActorAsync(string genres, int leadActorId);
        public Task<IEnumerable<Genre>> GetGenresListAsync();
        public Task<string> GetGenreNameAsync(int id);
    }
}
