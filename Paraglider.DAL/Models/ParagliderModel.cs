using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class ParagliderModel
    {
        public int ParagliderModelId { get; set; }
        public int NumberOfHomologation { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime DateOfHomologation { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal Size { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal MinimalWeight { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal MaximumWeight { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,1)")]
        public decimal FlightHours { get; set; }
        [Required]
        public int ParagliderId { get; set; }
        public Models.Paraglider Paraglider { get; set; }
    }
}
