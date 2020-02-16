﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Pilot
    {
        public Pilot()
        {
            Weight = 0;
        }
        public int PilotId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal Weight { get; set; }
        public int RoleId { get; set; }
        [DisplayFormat(NullDisplayText = "No Role")]
        public Role Role { get; set; }
        [Required]
        public IList<PilotMembership> PilotMemberships { get; set; }
        public IList<PilotTraineeship> PilotTraineeships { get; set; }
        public IList<PilotCertificate> PilotCertificates { get; set; }
        public IList<Flight> Flights { get; set; }
    }
}
