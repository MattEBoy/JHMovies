using JHMovies.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHMovies.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie
                    {
                        Rating  = "PG-13",
                        Category = "Action Adventure",
                        Title = "Indiana Jones and the Raiders of the Lost Ark",
                        Year = 1981,
                        Director = "Steven Spielberg",
                        LentTo = "",
                        Edited = false,
                        Notes = ""
                    }
                    );

                //save all changes
                context.SaveChanges();
            }
        }
    }
}
