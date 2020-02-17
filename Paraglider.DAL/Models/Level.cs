using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Level
    {
        public int LevelId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Traineeship> Traineeships { get; set; }
        public IList<LandingSite> LandingSites { get; set; }
        public IList<LaunchingSite> LaunchingSites { get; set; }
    }
}
