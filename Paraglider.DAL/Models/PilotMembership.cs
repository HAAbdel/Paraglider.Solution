using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class PilotMembership
    {
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }

        [Required]
        public DateTime DateOfPay { get; set; }

        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
