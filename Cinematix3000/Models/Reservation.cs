using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Klant")] 
        public int ClientID { get; set; }

        [Display(Name = "Klant")]
        public Client Client { get; set; }

        [Required]
        [Display(Name = "Voorstelling")]
        public int VenueMovieID { get; set; }

        [Display(Name = "Voorstelling")]
        public VenueMovie VenueMovie { get; set; }

        [Required]
        [Display(Name = "Stoelnummer")]
        public int SeatNumber { get; set; }

        [Display(Name = "Prijs")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Geholpen door")]
        public string UserName { get; set; }
    }
}
