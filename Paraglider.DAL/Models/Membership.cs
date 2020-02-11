using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
   public class Membership
    {
        public int MembershipId { get; set; }
        public decimal MembershipAmount { get; set; }
        [Required]
        public IList<PilotMembership> PilotMemberships { get; set; }
    }
}
