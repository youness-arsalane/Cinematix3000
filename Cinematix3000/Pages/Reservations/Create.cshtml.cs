using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinematix3000.Data;
using Cinematix3000.Models;

namespace Cinematix3000.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public CreateModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FirstName");
        ViewData["VenueMovieID"] = new SelectList(_context.VenueMovies, "ID", "ID");
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
