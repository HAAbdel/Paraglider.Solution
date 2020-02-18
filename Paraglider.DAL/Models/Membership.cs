using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
   public class Membership
    {
        //Primary key
        public int MembershipId { get; set; }
        //properties
        public decimal MembershipAmount { get; set; }
        //Soft delete
        [Required]
        public bool IsActive { get; set; }
        public IList<PilotMembership> PilotMemberships { get; set; }
    }
}
