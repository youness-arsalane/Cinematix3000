using Cinematix3000.Data;
using Cinematix3000.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cinematix3000.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Cinematix3000Context _context;

        public IndexModel(Cinematix3000Context context)
        {
            _context = context;
        }


        public IList<Movie> Movies { get; set; }
        
        public async Task OnGetAsync()
        {
            Movies = await _context.Movies.ToListAsync();

            Console.WriteLine("Test");
        }
    }
}
