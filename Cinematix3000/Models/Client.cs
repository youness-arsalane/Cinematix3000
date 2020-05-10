using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Display(Name = "Geboortedatum")]
        public string BirthDate { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
        public override string ToString()
        {
            return FullName();
        }

        [Display(Name = "Reserveringen")]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
