using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Level
    {
        //Primary key
        public int LevelId { get; set; }
        [Required]
        //Soft delete
        public bool IsActive { get; set; }
        //Properties
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        //Navigation properties
        public IList<Traineeship> Traineeships { get; set; }
        public IList<LandingSite> LandingSites { get; set; }
        public IList<LaunchingSite> LaunchingSites { get; set; }
    }
}
