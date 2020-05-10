using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinematix3000.Data;
using Cinematix3000.Models;

namespace Cinematix3000.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public DetailsModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Clients
                .Include(c => c.Reservations)
                    .ThenInclude(r => r.VenueMovie)
                        .ThenInclude(v => v.Venue)
                .Include(c => c.Reservations)
                    .ThenInclude(r => r.VenueMovie)
                        .ThenInclude(v => v.Movie)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
