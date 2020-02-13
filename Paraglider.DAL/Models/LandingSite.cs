using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class LandingSite
    {
        public int LandingSiteId { get; set; }
        [Required]
        [MaxLength(30)]
        public string SiteName { get; set; }
        [MaxLength(10)]
        public string Orientation { get; set; }
        [MaxLength(300)]
        public string Approach { get; set; }

        public IList<Flight> Flights { get; set; }
        [Required]
        public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}
