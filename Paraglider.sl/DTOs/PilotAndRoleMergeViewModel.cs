using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paraglider.sl.DTOs
{
    public class PilotAndRoleMergeViewModel
    {
        [Required]
        public PilotDetailDto PilotDetail { get; set; }
        public IEnumerable<RoleDTO> Roles { get; set; }

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
