using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class ParagliderModel
    {
        // PK
        public int ParagliderModelId { get; set; }

        // PROPERTIES + DATA ANNOTATION
        [Required]
        public string ModelType { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string NumberOfHomologation { get; set; }
        public DateTime DateOfHomologation { get; set; }
        [Required]
        public decimal Size { get; set; }
        [Required]
        public decimal MinimalWeight { get; set; }
        [Required]
        public decimal MaximumWeight { get; set; }

        // NAVIGATIONAL PROPERTIES 
        public IList<Paraglider> Paragliders { get; set; }

        // SOFT DELETE 
        [Required]
        public bool IsActive { get; set; }
    }
}
