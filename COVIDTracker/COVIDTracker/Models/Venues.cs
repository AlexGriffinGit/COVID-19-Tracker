using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Models
{
    public class Venues
    {
        [Key]
        public int VenueId { get; set; }

        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public int BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public List<Users> UsersList { get; set; }
    }
}
