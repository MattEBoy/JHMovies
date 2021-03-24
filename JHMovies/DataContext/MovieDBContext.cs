using JHMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHMovies.DataContext
{
    public class MovieDBContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }

        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {
            //public virtual DbSet<Book>  
        }
    }
}
