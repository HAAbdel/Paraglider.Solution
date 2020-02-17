using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public bool IsValide { get; set; }
        [Required]
        public int ParagliderId { get; set; }
        public Paraglider Paraglider { get; set; }
        [Required]
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        [Required]
        public DateTime FlightDate { get; set; }
        public decimal FlightDuration { get; set; }
        [Required]
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
