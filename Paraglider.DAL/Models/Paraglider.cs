using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Paraglider
    {
        public int ParagliderId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateOfService { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateOfUse { get; set; }
        public IList<ParagliderModel> ParagliderModels { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
