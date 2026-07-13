using Microsoft.AspNetCore.Mvc;
using TMDbMovies.Services;

namespace TMDbMovies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                ViewBag.Error = "Please enter a movie title.";
                return View("Index");
            }

            var result = await _movieService.GetMovieByTitleAsync(title);

            if (result == null)
            {
                ViewBag.Error = "Movie not found.";
                return View("Index");
            }

            return View("Index", result);
        }
    }
}