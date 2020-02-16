using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
   public class Membership
    {
        public int MembershipId { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal MembershipAmount { get; set; }
        public bool IsActiv { get; set; }
        [Required]
        public IList<PilotMembership> PilotMemberships { get; set; }
    }
}
