using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinematix3000.Models
{
    public class Cinema
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Straat")]
        public string Street { get; set; }

        [Display(Name = "Huisnummer")]
        public string HouseNumber { get; set; }

        [Display(Name = "Postcode")]
        public string PostalCode { get; set; }

        [Display(Name = "Plaats")]
        public string Place { get; set; }

        public ICollection<Venue> Venues { get; set; }
    }
}
