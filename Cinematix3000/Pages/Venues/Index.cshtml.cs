using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinematix3000.Data;
using Cinematix3000.Models;

namespace Cinematix3000.Pages.Venues
{
    public class IndexModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public IndexModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        public IList<Venue> Venues { get; set; }

        public async Task OnGetAsync()
        {
            Venues = await _context.Venues
                .Include(v => v.Cinema).ToListAsync();
        }
    }
}
