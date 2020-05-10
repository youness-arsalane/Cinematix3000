using System.Linq;
using Cinematix3000.Models;
using Microsoft.AspNetCore.Identity;

namespace Cinematix3000.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Cinematix3000Context context)
        {
            context.Database.EnsureCreated();

            if (!context.Cinemas.Any())
            {
                context.Cinemas.Add(new Cinema
                {
                    Name = "Bioscoop 1",
                    Street = "Kruidenlaan",
                    HouseNumber = "186",
                    PostalCode = "5044CR",
                    Place = "Tilburg"
                });

                context.SaveChanges();
            }

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
            
            if (!context.Users.Any())
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "pietjepuk",
                    NormalizedUserName = "PIETJEPUK@GMAIL.COM",
                    Email = "pietjepuk@gmail.com",
                    NormalizedEmail = "PIETJEPUK@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEFOHVdpi1nSHoO5oX4sVCyiyojrqwFMpYlTfrdAz6rchUx6sY/9zOUZkzwdgsX7iMQ==", // Test12-34
                    SecurityStamp = "27FG22CQXFSSCCTFH4MDPDETK7IIUOOY",
                    ConcurrencyStamp = "667685fc-d613-4ea7-879a-37752abc7a00",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                });

                context.SaveChanges();
            }

        }
    }
}