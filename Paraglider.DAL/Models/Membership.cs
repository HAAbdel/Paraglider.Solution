using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.Models
{
   public class Membership
    {
        public Guid MembershipId { get; set; }

        public virtual ICollection<Pilot> Pilots { get; set; }
    }
}
