using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Paraglider
    {
        //Primary key
        public int ParagliderId { get; set; }
        //Soft delete
        public bool IsActive { get; set; }
        //properties
        public DateTime DateOfService { get; set; }
        public DateTime DateOfUse { get; set; }
        [Required]
        public decimal FlightHours { get; set; }
        //Navigation properties
        public int ParagliderModelId { get; set; }
        public ParagliderModel ParagliderModel { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
