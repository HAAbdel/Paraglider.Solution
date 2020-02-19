using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParagliderAPP.Models
{
    public class PilotAndRoleMergeViewModel
    {
        public PilotDetailDto PilotDetail { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
