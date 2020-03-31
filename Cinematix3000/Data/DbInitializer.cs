using Cinematix3000.Data;
using Cinematix3000.Models;
using System;
using System.Linq;

namespace Cinematix3000.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Cinematix3000Context context)
        {
                Console.WriteLine("Test1");
            context.Database.EnsureCreated();

            if (!context.Venues.Any())
            {
                var venues = new Venue[]
                {
                new Venue{CinemaID = 1, Name = "Zaal 1", Capacity = 90},
                new Venue{CinemaID = 1, Name = "Zaal 2", Capacity = 100},
                new Venue{CinemaID = 1, Name = "Zaal 3", Capacity = 75}
                };

                foreach (Venue s in venues)
                {
                    context.Venues.Add(s);
                }

                context.SaveChanges();
            } else
            {
                Console.WriteLine("Test");
            }

            if (!context.Movies.Any())
            { 
                var movies = new Movie[]
                {
                new Movie{Title = "IT", Director = "Stephen King", Cast = "Clown", Description = "Scary", Runtime = 180},
                new Movie{Title = "Jurrasic Park", Director = "Stephen Spielberg", Cast = "Dinosaurs", Description = "Scary", Runtime = 165},
                };

                foreach (Movie s in movies)
                {
                    context.Movies.Add(s);
                }

                context.SaveChanges();
            }

            
        }
    }
}