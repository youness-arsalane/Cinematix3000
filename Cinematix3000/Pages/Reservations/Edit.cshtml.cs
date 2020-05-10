using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinematix3000.Data;
using Cinematix3000.Models;

namespace Cinematix3000.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public EditModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.VenueMovie).FirstOrDefaultAsync(m => m.ID == id);

            if (Reservation == null)
            {
                return NotFound();
            }

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

            ViewData["ClientID"] = new SelectList(newClients, "ID", "ToString");
            ViewData["VenueMovieID"] = new SelectList(newVenueMovies, "ID", "ToString");

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ID == id);
        }
    }
}
