using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.sl.DTOs
{
    class ParagliderAndModelDTO
    {
        [Required]
        public ParagliderDetailDTO paragliderDetail { get; set; }
        [Required]
        public IEnumerable<ParagliderModelDTO> Models {get;set;}

    }
}
