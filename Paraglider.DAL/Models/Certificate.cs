using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Certificate
    {
        //Primary key
        public int CertificateId { get; set; }
        //Soft delete
        [Required]
        public bool IsValide { get; set; }
        //Properties
        [Required]
        public string CerttificatName { get; set; }
        //Naviagation properties
        public IList<PilotCertificate> PilotCertificates { get; set; }
        public IList<Traineeship> Traineeships { get; set; }

    }
}
