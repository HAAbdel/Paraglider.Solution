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
        public string LandingSiteName { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public string Approach { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
