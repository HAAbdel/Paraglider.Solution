using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class ParagliderConfig : IEntityTypeConfiguration<Models.Paraglider>
    {
        public void Configure(EntityTypeBuilder<Models.Paraglider> entity)
        {
            entity.HasQueryFilter(p => p.IsActive);

            entity.Property(p => p.DateOfService).HasColumnType("date");
            entity.Property(p => p.DateOfUse).HasColumnType("date");
            entity.Property(p => p.FlightHours).HasColumnType("decimal(5,2)");

            entity.HasOne(p => p.ParagliderModel)
                .WithMany(p => p.Paragliders)
                .HasForeignKey(p => p.ParagliderModelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}