using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHMovies.Models
{
    public class Storage
    {
        //array of movies
        private static List<Movie> movies = new List<Movie>();

        public static IEnumerable<Movie> Movies => movies;
        //adds to movie
        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
