using JHMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JHMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //this shows the home view
        public IActionResult Index()
        {
            return View();
        }
        //this is called only for 'get' calls and shows the movie entry view
        [HttpGet]
        public IActionResult Entry()
        {
            return View();
        }
        //this method is only called for post method calls and displays the confirmation page or the same page if errors were introduced 
        [HttpPost]
        public IActionResult Entry(Movie movie)
        {
            //this only takes us the success screen if the information is entered correctly. this protects from people using something like postman to enter in values we don't want
            if(movie.Category == null   || movie.Title == null  || movie.Director == null   || movie.Rating == null || movie.Year == 0 ||
                movie.Category == ""    || movie.Title == ""    || movie.Director == ""     || movie.Rating == "")
            {
                return View();
            }
            else
            {
                Storage.AddMovie(movie);
                return View("Confirmation", movie);
            }

        }
        //this shows the list page
        public IActionResult List()
        {
            return View(Storage.Movies);
        }
        //this shows the podcasts page
        public IActionResult Podcasts()
        {
            return View();
        }
        //this shows the built in privicy page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
