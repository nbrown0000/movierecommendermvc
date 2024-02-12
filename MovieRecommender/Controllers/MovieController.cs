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
        private readonly ILogger<MovieController> _logger;
        
        public MovieController(ITmdbAPIContext tmdbAPIContext, ILogger<MovieController> logger)
        {
            _tmdbAPIContext = tmdbAPIContext;
            _logger = logger;
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

        public async Task<IActionResult> Search(string title, int page = 1)
        {
            MovieSearchResults movieSearchResults = await _tmdbAPIContext.SearchMoviesByTitleAsync(title.ToString(), page);

            return View(movieSearchResults);
        }

        public async Task<IActionResult> Recommendations(int movieId, int page = 1)
        {
            MovieDetail movieDetail = await _tmdbAPIContext.GetMovieByIdAsync(movieId);

            // recommendations 
            if (movieDetail.Genres == null || movieDetail.Genres.Count == 0)
            {
                // TODO: log error
                _logger.LogWarning("");
                // TODO: contingency for empty genres
            }

            try {
                MovieRecommendationsModel recommendedMovies = await _tmdbAPIContext.GetMovieRecommendationsWithSameGenres(movieDetail.Genres, page);
                recommendedMovies.MovieId = movieId;
                recommendedMovies.Genres = movieDetail.Genres;
                recommendedMovies.SearchTitle = movieDetail.Title;
                return View(recommendedMovies);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching movie recommendations: {ex}", ex);
                return RedirectToAction("Error", "Home", ex);
            }

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
