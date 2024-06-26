﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinematix3000.Data;
using Cinematix3000.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinematix3000.Pages.VenueMovies
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
            List<Venue> venues = _context.Venues
                .Include(v => v.Cinema).ToList();

            List<object> newVenues = new List<object>();
            foreach (Venue venue in venues)
            {
                newVenues.Add(new
                {
                    venue.ID,
                    FullName = venue.Cinema.Name + " (Zaal: " + venue.Name + ")"
                });
            }

            ViewData["MovieID"] = new SelectList(_context.Movies, "ID", "Title");
            ViewData["VenueID"] = new SelectList(newVenues, "ID", "FullName");
            
            return Page();
        }

        [BindProperty]
        public VenueMovie VenueMovie { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VenueMovies.Add(VenueMovie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
