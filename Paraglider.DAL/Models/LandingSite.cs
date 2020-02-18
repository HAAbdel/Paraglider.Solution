using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class LandingSite
    {
        //Primary Key
        public int LandingSiteId { get; set; }
        //Properties :
        [Required]
        public string LandingSiteName { get; set; }
        public string Approach { get; set; }
        //Soft delete
        [Required]
        public bool IsActive { get; set; }
        // Navigation properties :
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}
