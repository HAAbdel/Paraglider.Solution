using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    internal class ParagliderModelConfig : IEntityTypeConfiguration<ParagliderModel>
    {
        public void Configure(EntityTypeBuilder<ParagliderModel> entity)
        {
            entity.HasQueryFilter(p => p.IsActive);

            entity.Property(p => p.DateOfHomologation).HasColumnType("date");

            entity.HasMany(p => p.Paragliders)
                .WithOne(p => p.ParagliderModel)
                .HasForeignKey(p => p.ParagliderModelId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

