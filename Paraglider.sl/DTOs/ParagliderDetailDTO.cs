using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.sl.DTOs
{
    class ParagliderDetailDTO
    {
        public int Id { get; set; }
        public DateTime DateOfService { get; set; }
        public DateTime DateOfUse { get; set; }
        public decimal FlightHours { get; set; }
        public ParagliderModelDTO paragliderModel { get; set; }
    }
}
