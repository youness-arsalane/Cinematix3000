using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ClientID { get; set; }

        [Display(Name = "Klant")]
        public Client Client { get; set; }

        [Required]
        public int VenueMovieID { get; set; }

        [Display(Name = "Voorstelling")]
        public VenueMovie VenueMovie { get; set; }

        [Required]
        [Display(Name = "Stoelnummer")]
        public int SeatNumber { get; set; }

        [Required]
        [Display(Name = "Prijs")]
        public double Price { get; set; }

        //[Required]
        //public string ApplicationUserID { get; set; }

        //[Display(Name = "Geholpen door")]
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
