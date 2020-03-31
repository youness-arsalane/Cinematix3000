using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinematix3000.Data;
using Cinematix3000.Models;

namespace Cinematix3000.Pages.VenueMovies
{
    public class DetailsModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public DetailsModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        public VenueMovie VenueMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueMovie = await _context.VenueMovies
                .Include(v => v.Movie)
                .Include(v => v.Venue)
                .Include(v => v.Reservations)
                .ThenInclude(r => r.Client)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (VenueMovie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
