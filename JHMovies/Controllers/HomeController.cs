using JHMovies.DataContext;
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
        private MovieDBContext _context;
        public HomeController(ILogger<HomeController> logger, MovieDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        //this shows the home view
        public IActionResult Index()
        {
            return View();
        }
        //this is called only for 'get' calls and shows the movie entry view
        //[HttpGet]
        //public IActionResult Entry()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Entry(int movieId = -1)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.MovieID == movieId);

            if(movie != null)
            {
                return View(movie);
            }
            else
            {
                return View();
            }
        }
        //this method is only called for post method calls and displays the confirmation page or the same page if errors were introduced 
        [HttpPost]
        public IActionResult Entry(Movie movie = null, string type = "", int movieId = -1)
        {
            //this only takes us the success screen if the information is entered correctly. this protects from people using something like postman to enter in values we don't want
            if (type == "remove")
            {
                movie = _context.Movies.FirstOrDefault(m => m.MovieID == movieId);
                if (movie != null)
                {
                    _context.Remove(movie);
                    _context.SaveChanges();
                    return View("Confirmation", movie);
                }
                else
                {
                    return View("Error");
                }
            }
            else if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                Movie searchedMovie = _context.Movies.FirstOrDefault(m => m.MovieID == movieId);
                if (searchedMovie != null)
                {
                    //the movie already exists so it's an edit
                    _context.Remove(searchedMovie);
                    _context.SaveChanges();

                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                    return View("Confirmation", movie);
                }
                else
                {
                    //commenting out old way
                    //Storage.AddMovie(movie);
                    //the movie is a n
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                    return View("Confirmation", movie);
                }
            }
        }
        //this shows the list page
        public IActionResult List()
        {
            return View(_context.Movies);
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
