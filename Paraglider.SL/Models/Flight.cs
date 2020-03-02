using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Flight
    {
        //Primary Key
        public int FlightId { get; set; }
        //Properties
        [Required]
        public DateTime FlightDate { get; set; }
        public decimal FlightDuration { get; set; }

        //Soft delete
        [Required]
        public bool IsActive { get; set; }

        //Navigation properties
        public int ParagliderId { get; set; }
        public Paraglider Paraglider { get; set; }
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
