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
        [Column(TypeName = "DateTime")]
        public DateTime DateOfService { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateOfUse { get; set; }
        [Required]
        public int ParagliderModelId { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,1)")]
        public decimal FlightHours { get; set; }
        public ParagliderModel ParagliderModel { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
