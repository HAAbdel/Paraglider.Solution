using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class PilotCertificate
    {
        //Properties
        [Required]
        public DateTime DateOfSucc { get; set; }
        //Navigation properties And CompositKey
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; }
    }
}
