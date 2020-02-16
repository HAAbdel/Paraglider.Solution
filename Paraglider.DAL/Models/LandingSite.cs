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
        public string LandingSiteName { get; set; }
        [MaxLength(300)]
        public string Approach { get; set; }
        [Required]
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
