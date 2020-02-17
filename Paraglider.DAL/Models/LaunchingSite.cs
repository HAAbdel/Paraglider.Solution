using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class LaunchingSite
    {
        public int LaunchingSiteId { get; set; }
        [Required]
        public string LaunchingSiteName { get; set; }
        public string Approach { get; set; }
        [Required]
        public int LevelId { get; set; }
        public Level Level { get; set; }
        [Required]
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
