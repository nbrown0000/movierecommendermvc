using Microsoft.AspNetCore.Mvc;
using MovieRecommender.Data;
using MovieRecommender.Interfaces;
using MovieRecommender.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using MovieRecommender.Helper;

namespace MovieRecommender.Controllers
{
    public class MovieController : Controller
    {
        private readonly ITmdbAPIContext _tmdbAPIContext;
        
        public MovieController(ITmdbAPIContext tmdbAPIContext)
        {
            _tmdbAPIContext = tmdbAPIContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchByTitle()
        {
            return View("SearchByTitle");
        }

        [HttpPost]
        public async Task<IActionResult> SearchByTitle(string searchTitle, int page = 1)
        {
            // TODO: Sanitize data from form input

            return RedirectToAction("Search", new { title = searchTitle, page });
        }

        //public async Task<IActionResult> Search(SearchMovieModel searchMovieModel)
        public async Task<IActionResult> Search(string title, int page = 1)
        {
            MovieSearchResults movieSearchResults = await _tmdbAPIContext.SearchMoviesByTitleAsync(title.ToString(), page);

            return View(movieSearchResults);
        }

        public async Task<IActionResult> Recommendations(int movieId, int page = 1)
        {
            MovieDetail movieDetail = await _tmdbAPIContext.GetMovieByIdAsync(movieId);

            if (movieDetail.Genres == null || movieDetail.Genres.Count == 0)
            {
                // TODO: log error
                // TODO: contingency for empty genres
            }
            MovieRecommendationsModel recommendedMovies = await _tmdbAPIContext.GetMovieRecommendationsWithSameGenres(movieDetail.Genres, page);
            recommendedMovies.MovieId = movieId;
            recommendedMovies.Genres = movieDetail.Genres;

            return View(recommendedMovies);
        }

        public async Task<IActionResult> Detail(int movieId)
        {
            MovieDetail movieDetail = await _tmdbAPIContext.GetMovieByIdAsync(movieId);

            IEnumerable<Actor> movieCast = await _tmdbAPIContext.GetCastByMovieIdAsync(movieId);
            movieDetail.Cast = movieCast.ToList();

            return View(movieDetail);
        }
    }
}
