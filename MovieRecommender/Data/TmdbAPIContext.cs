using MovieRecommender.Helper;
using MovieRecommender.Interfaces;
using MovieRecommender.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MovieRecommender.Data
{
    public class TmdbAPIContext : ITmdbAPIContext
    {
        private readonly IConfiguration _appConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _tmdbApiKey;
        private HttpClient _client;
        private IEnumerable<Genre> _genreMasterList;

        public TmdbAPIContext(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _appConfig = config;
            _httpClientFactory = httpClientFactory;

            _client = new HttpClient { BaseAddress = new Uri("https://api.themoviedb.org/3/") };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _tmdbApiKey = _appConfig["TmdbApiKey"];
        }

        public async Task<IEnumerable<Movie>> SearchMoviesByTitleAsync(string title)
        {
            string queryUrl = $"search/movie?api_key={_tmdbApiKey}&include_adult=false&page=1&query={title}";
            HttpRequestMessage request = new HttpRequestMessage(method: HttpMethod.Get, queryUrl);
            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                // TODO: log error message
            }

            dynamic result = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(result);
            var movieList = jsonObject["results"].ToObject<List<Movie>>();
            return movieList;
        }

        public async Task<MovieDetail> GetMovieByIdAsync(int id)
        {
            string queryUrl = $"movie/{id}?api_key={_tmdbApiKey}";

            HttpRequestMessage request = new HttpRequestMessage(method: HttpMethod.Get, queryUrl);
            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                // TODO: log error message
            }

            dynamic result = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(result);
            var movie = jsonObject.ToObject<MovieDetail>();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMovieRecommendationsWithSameGenres(IEnumerable<Genre> genres)
        {
            string queryUrl = $"discover/movie?api_key={_tmdbApiKey}&with_genres={StringFunctions.ConvertGenreObjectsListToStringOfIds(genres.ToList())}";

            HttpRequestMessage request = new HttpRequestMessage(method: HttpMethod.Get, queryUrl);
            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                // TODO: log error message
            }

            dynamic result = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(result);
            var recommendedMovieList = jsonObject["results"].ToObject<List<Movie>>();
            return recommendedMovieList;
        }

        public async Task<IEnumerable<Actor>> GetCastByMovieIdAsync(int id)
        {
            string queryUrl = $"movie/{id}/credits?api_key={_tmdbApiKey}";

            HttpRequestMessage request = new HttpRequestMessage(method: HttpMethod.Get, queryUrl);
            HttpResponseMessage response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                // TODO: log error message
            }

            dynamic result = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(result);
            var castList = jsonObject["cast"].ToObject<List<Actor>>(); ;
            return castList;
        }        

    }
}
