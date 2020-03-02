using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class LaunchingSite
    {
        //Primary key
        public int LaunchingSiteId { get; set; }
        //Soft delete
        [Required]
        public bool IsActive { get; set; }
        //Properties
        [Required]
        public string LaunchingSiteName { get; set; }
        public string Approach { get; set; }
        //Navigation properties
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
