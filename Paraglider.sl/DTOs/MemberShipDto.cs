using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.sl.DTOs
{
    public class MemberShipDto
    {
        public int id { get; set; }
        public int numberOfSubscribers { get; set; }
        public decimal membershipAmount { get; set; }
    }
}
