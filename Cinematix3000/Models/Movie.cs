using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Display(Name = "Regisseur")]
        public string Director { get; set; }

        [Display(Name = "Cast")]
        public string Cast { get; set; }

        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Display(Name = "Looptijd (in minuten)")]
        public int Runtime { get; set; }

        [Display(Name = "Voorstellingen")]
        public ICollection<VenueMovie> VenueMovies { get; set; }
    }
}
