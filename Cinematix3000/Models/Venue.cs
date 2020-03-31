using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class Venue
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CinemaID { get; set; }

        [Display(Name = "Bioscoop")]
        public Cinema Cinema { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Aantal stoelen")]
        public int Capacity { get; set; }


        [Display(Name = "Voorstellingen")]
        public ICollection<VenueMovie> VenueMovies { get; set; }
    }
}
