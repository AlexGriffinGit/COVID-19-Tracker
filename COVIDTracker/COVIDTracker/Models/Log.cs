using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COVIDTracker.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public Venues Venue { get; set; }
        public Users User { get; set; }
    }
}
