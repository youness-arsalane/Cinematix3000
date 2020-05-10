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
        [Display(Name = "Film")]
        public int MovieID { get; set; }

        [Display(Name = "Film")]
        public virtual Movie Movie { get; set; }
        
        [Required]
        [Display(Name = "Zaal")]
        public int VenueID { get; set; }

        [Display(Name = "Zaal")]
        public virtual Venue Venue { get; set; }

        [Required]
        [Display(Name = "Begint op")]
        public DateTime StartDateTime { get; set; }

        public override String ToString()
        {
            return ID + ": " + Movie.Title + " in " + Venue.Name + " om " + StartDateTime.ToString();
        }

        [Display(Name = "Reserveringen")]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
