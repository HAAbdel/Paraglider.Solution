using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class TraineeshipConfiguration : IEntityTypeConfiguration<Traineeship>
    {
        public void Configure(EntityTypeBuilder<Traineeship> builder)
        {
            builder.HasOne(sc => sc.Certificate).WithMany(s => s.Traineeships).HasForeignKey(g => g.CertificateId);
        }
    }
}
