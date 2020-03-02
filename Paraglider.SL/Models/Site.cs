using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Site
    {
        //Primary key
        public int SiteId { get; set; }
        //Soft delete
        [Required]
        public bool IsActive { get; set; }
        //Properties
        [Required]
        public string CommuneName { get; set; }
        public string Orientation { get; set; }
        public string ZipCode { get; set; }
        public string SiteGeoCoordinate { get; set; }
        //Navigation properties
        public IList<LaunchingSite> LaunchingSites { get; set; }
        public IList<LandingSite> LandingSites { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
