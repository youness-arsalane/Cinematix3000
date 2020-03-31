using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class VenueMovie
    {
        [Key]
        public int ID { get; set; }
     
        [Required]
        public int MovieID { get; set; }

        [Display(Name = "Film")]
        public Movie Movie { get; set; }
        
        [Required]
        public int VenueID { get; set; }

        [Display(Name = "Zaal")]
        public Venue Venue { get; set; }

        [Required]
        [Display(Name = "Begint op")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "Reserveringen")]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
