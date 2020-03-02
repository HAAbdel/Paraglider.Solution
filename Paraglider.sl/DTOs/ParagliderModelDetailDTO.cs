using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.sl.DTOs
{
    public class ParagliderModelDetailDTO
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string ModelType { get; set; }
        public string NumberOfHomologation { get; set; }
        public DateTime DateOfHomologation { get; set; }
        public decimal Size { get; set; }
        public decimal MinimalWeight { get; set; }
        public decimal MaximumWeight { get; set; }
        public int NumberOfThisModel { get; set; }
    }
}
