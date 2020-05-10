using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinematix3000.Data;
using Cinematix3000.Models;
using System.Globalization;

namespace Cinematix3000.Pages.VenueMovies
{
    public class IndexModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public IndexModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        public IList<VenueMovie> VenueMovies { get; set; }

        public async Task OnGetAsync(string? startDate = null, string? endDate = null)
        {
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;

            if (startDate != null && endDate != null)
            {
                DateTime newStartDate = DateTime.ParseExact(startDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime newEndDate = DateTime.ParseExact(endDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                VenueMovies = await _context.VenueMovies
                    .Include(v => v.Movie)
                    .Include(v => v.Venue)
                    .Include(v => v.Venue.Cinema)
                    .Include(v => v.Reservations)
                    .Where(v => v.StartDateTime > newStartDate && v.StartDateTime < newEndDate)
                    .ToListAsync();
            } else
            {
                VenueMovies = await _context.VenueMovies
                    .Include(v => v.Movie)
                    .Include(v => v.Venue)
                    .Include(v => v.Venue.Cinema)
                    .Include(v => v.Reservations)
                    .ToListAsync();
            }
        }
    }
}
