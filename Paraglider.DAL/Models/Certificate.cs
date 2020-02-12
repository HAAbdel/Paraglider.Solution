﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Certificate
    {
        public int CertificateId { get; set; }
        [Required]
        public string CerttificatName { get; set; }
        public IList<PilotCertificate> PilotCertificates { get; set; }
    }
}
