using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Site
    {
        public int SiteId { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string CommuneName { get; set; }
        public string Orientation { get; set; }
        public string ZipCode { get; set; }
        public string SiteGeoCoordinate { get; set; }
        public IList<LaunchingSite> LaunchingSites { get; set; }
        public IList<LandingSite> LandingSites { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
