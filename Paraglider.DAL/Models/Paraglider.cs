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
        public bool IsActive { get; set; }
        public DateTime DateOfService { get; set; }
        public DateTime DateOfUse { get; set; }
        [Required]
        public int ParagliderModelId { get; set; }
        [Required]
        public decimal FlightHours { get; set; }
        public ParagliderModel ParagliderModel { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
