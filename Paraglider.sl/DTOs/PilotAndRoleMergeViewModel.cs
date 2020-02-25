using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paraglider.sl.DTOs
{
    public class PilotAndRoleMergeViewModel
    {
        public PilotDetailDto PilotDetail { get; set; }
        public IEnumerable<RoleDto> Roles { get; set; }
        public int RoleId { get; set; }

        internal Pilot ToPilot()
        {
            //Work in progress
            Pilot pilot = new Pilot()
            {
                FirstName = this.PilotDetail.FirstName,
                LastName = this.PilotDetail.LastName,
                Email = this.PilotDetail.Email,
                Weight = this.PilotDetail.Weight,
            };
            return pilot;
        }
    }
}
