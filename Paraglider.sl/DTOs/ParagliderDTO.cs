using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.sl.DTOs
{
    class ParagliderDTO
    {
        public int Id { get; set; }
        public decimal TotalHoursFlight { get; set; }
        public ParagliderModel ParagliderModel { get; set; }
    }
}
