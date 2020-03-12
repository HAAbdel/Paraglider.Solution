using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.sl.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int pilotId { get; set; }
        public string pilotName { get; set; }
    }
}
