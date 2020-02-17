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
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(80)]
        public string Description { get; set; }
        public IList<Traineeship> Traineeships { get; set; }
        public IList<LandingSite> LandingSites { get; set; }
        public IList<LaunchingSite> LaunchingSites { get; set; }
    }
}
