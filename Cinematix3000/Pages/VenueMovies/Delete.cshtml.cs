﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public DeleteModel(Cinematix3000.Data.Cinematix3000Context context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueMovie = await _context.VenueMovies.FindAsync(id);

            if (VenueMovie != null)
            {
                _context.VenueMovies.Remove(VenueMovie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
