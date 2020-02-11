using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotTraineeshipConfiguration : IEntityTypeConfiguration<PilotTraineeship>
    {
        public void Configure(EntityTypeBuilder<PilotTraineeship> builder)
        {
            builder.HasKey(sc => new { sc.PilotId, sc.TraineeshipId });
            builder.HasOne(sc => sc.Traineeship).WithMany(p => p.PilotTraineeships).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
