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

        [HttpPost]
        public async Task<IActionResult> Search(SearchMovieModel searchMovieModel)
        {
            // TODO: Sanitize data from form input
            var movieList = await _tmdbAPIContext.SearchMoviesByTitleAsync(searchMovieModel.Title);

            return View("Index", movieList);
        }

        public async Task<IActionResult> Recommendations(int movieId)
        {
            MovieDetail movieDetail = await _tmdbAPIContext.GetMovieByIdAsync(movieId);
            var genresString = StringFunctions.ConvertGenreObjectsListToStringOfIds(movieDetail.Genres);
            var castList = await _tmdbAPIContext.GetCastByMovieIdAsync(movieId);
            var recommendedMovies = await _tmdbAPIContext.GetRecommendationsMatchingGenresAndLeadActorAsync(genresString, castList.First().Id);

            return View(recommendedMovies);
        }

        public async Task<IActionResult> Detail(int movieId)
        {
            MovieDetail movieDetail = await _tmdbAPIContext.GetMovieByIdAsync(movieId);

            return View(movieDetail);
        }
    }
}
