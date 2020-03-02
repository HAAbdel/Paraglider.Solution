using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Pilot
    {
        //Primary key
        public int PilotId { get; set; }
        //Soft delete
        [Required]
        //Properties
        public bool IsActive { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public decimal Weight { get; set; }
        //Navigation Properties
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public IList<PilotMembership> PilotMemberships { get; set; }
        public IList<PilotTraineeship> PilotTraineeships { get; set; }
        public IList<PilotCertificate> PilotCertificates { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
