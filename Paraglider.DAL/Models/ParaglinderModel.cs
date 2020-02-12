using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class ParaglinderModel
    {
        public int ParaglinderModelId { get; set; }
        public int NumberOfHomologation { get; set; }
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
        public int ParaglinderId { get; set; }
        public Paraglinder Paraglinder { get; set; }
    }
}
