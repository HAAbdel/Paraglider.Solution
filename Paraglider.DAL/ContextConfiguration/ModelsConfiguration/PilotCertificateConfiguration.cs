using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotCertificateConfiguration : IEntityTypeConfiguration<PilotCertificate>
    {
        public void Configure(EntityTypeBuilder<PilotCertificate> builder)
        {
            builder.HasKey(sc => new { sc.CertificateId, sc.PilotId });
        }
    }
}
