using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(18, 120)]
        public int Age { get; set; }

        [Required]
        public string CarMake { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Range(1900, 2100)]
        public int CarYear { get; set; }

        [Range(0, 100)]
        public int SpeedingTickets { get; set; }

        public bool HasDUI { get; set; }

        public bool HasFullCoverage { get; set; }

        public decimal Quote { get; set; }  // This will be calculated on the server side
    }
}
