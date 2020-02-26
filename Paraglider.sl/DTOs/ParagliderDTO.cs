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
        public string ParagliderModelName { get; set; }
        public int ParagliderModelId { get; set; }
    }
}
