using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class LaunchingSite
    {
        public int LaunchingSiteId { get; set; }
        public string  SiteName { get; set; }
        public string Orientation { get; set; }
        public string Approach { get; set; }

        public IList<Flight> Flights { get; set; }
    }
}
