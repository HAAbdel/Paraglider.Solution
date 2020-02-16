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
        [Required]
        public string ModelType { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string NumberOfHomologation { get; set; }
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
        public IList<Paraglider> Paragliders { get; set; }
    }
}
