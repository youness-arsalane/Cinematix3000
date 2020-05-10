using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinematix3000.Data;
using Cinematix3000.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Cinematix3000.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(
            UserManager<IdentityUser> userManager, 
            Cinematix3000.Data.Cinematix3000Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            List<Client> clients = _context.Clients.ToList();
            List<object> newClients = new List<object>();
            foreach (Client client in clients)
            {
                newClients.Add(new
                {
                    client.ID,
                    ToString = client.ToString()
                });
            }

            List<VenueMovie> venueMovies = _context.VenueMovies
                .Include(v => v.Movie)
                .Include(v => v.Venue).ToList();

            List<object> newVenueMovies = new List<object>();
            foreach (VenueMovie venueMovie in venueMovies)
            {
                newVenueMovies.Add(new
                {
                    venueMovie.ID,
                    ToString = venueMovie.ToString()
                });
            }

            ViewData["UserName"] = _userManager.GetUserName(User);
            ViewData["ClientID"] = new SelectList(newClients, "ID", "ToString");
            ViewData["VenueMovieID"] = new SelectList(newVenueMovies, "ID", "ToString");

            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
