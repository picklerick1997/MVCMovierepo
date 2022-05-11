using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;


namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return; // DB has been seeded 
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("12-2-1989"),
                        Genre = "Romantic Comedy",
                        Rating = "12",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("13-3-1984"),
                        Genre = "Comedy",
                        Rating = "15",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("23-2-1986"),
                        Genre = "Comedy",
                        Rating = "15",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("15-4-1959"),
                        Genre = "Western",
                        Rating = "PG",
                        Price = 6.99M
                    },

                    new Movie
                    {
                        Title = "Pulp Fiction",
                        ReleaseDate = DateTime.Parse("14-10-1994"),
                        Genre = "Action comedy",
                        Rating = "18",
                        Price = 10M
                    },

                    new Movie
                    {
                        Title = "The Matrix",
                        ReleaseDate = DateTime.Parse("31-3-1999"),
                        Genre = "Action, sci-fi",
                        Rating = "18",
                        Price = 10M
                    },

                    new Movie
                    {
                        Title = "Transformers",
                        ReleaseDate = DateTime.Parse("03-07-2007"),
                        Genre = "Action, Comedy, Sci-fi",
                        Rating = "18",
                        Price = 10M
                    }

                 ) ;
                context.SaveChanges();
            }
        }
    }
}
