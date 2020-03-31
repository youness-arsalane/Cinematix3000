using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int CinemaID { get; set; }

        [Display(Name = "Bioscoop")]
        public Cinema Cinema { get; set; }
    }
}
