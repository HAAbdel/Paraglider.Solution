using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Paraglinder
    {
        public int ParaglinderId { get; set; }
        [Required]
        public string Brand { get; set; }
        public DateTime DateOfService { get; set; }
        public DateTime DateOfUse { get; set; }
        public IList<ParaglinderModel> ParaglinderModels { get; set; }
    }
}
