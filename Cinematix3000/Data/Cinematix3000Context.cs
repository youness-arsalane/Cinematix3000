using Cinematix3000.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cinematix3000.Data
{
    public class Cinematix3000Context : IdentityDbContext
    {
        public Cinematix3000Context(DbContextOptions<Cinematix3000Context> options)
            : base(options)
        {
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<VenueMovie> VenueMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cinema>().ToTable("Cinema");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Venue>().ToTable("Venue");
            modelBuilder.Entity<VenueMovie>().ToTable("VenueMovie");
        }
    }
}
