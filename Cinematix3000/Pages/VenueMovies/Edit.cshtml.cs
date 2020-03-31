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

namespace Cinematix3000.Pages.VenueMovies
{
    public class EditModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public EditModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        [BindProperty]
        public VenueMovie VenueMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueMovie = await _context.VenueMovies
                .Include(v => v.Movie)
                .Include(v => v.Venue).FirstOrDefaultAsync(m => m.ID == id);

            if (VenueMovie == null)
            {
                return NotFound();
            }
           ViewData["MovieID"] = new SelectList(_context.Movies, "ID", "ID");
           ViewData["VenueID"] = new SelectList(_context.Venues, "ID", "Name");
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

            _context.Attach(VenueMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueMovieExists(VenueMovie.ID))
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

        private bool VenueMovieExists(int id)
        {
            return _context.VenueMovies.Any(e => e.ID == id);
        }
    }
}
