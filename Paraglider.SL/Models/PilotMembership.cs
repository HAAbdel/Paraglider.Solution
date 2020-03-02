using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class PilotMembership
    {
        //Properties
        [Required]
        public DateTime DateOfPay { get; set; }
        //Navigation properties And CompositKey
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
