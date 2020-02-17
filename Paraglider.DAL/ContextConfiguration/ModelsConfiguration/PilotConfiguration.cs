using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotConfiguration : IEntityTypeConfiguration<Pilot>
    {
        public void Configure(EntityTypeBuilder<Pilot> entity)
        {
            entity.HasOne<Role>(p => p.Role)
                .WithOne(c => c.Pilot)
                .HasForeignKey<Pilot>(l => l.RoleId);
            entity.Property(p => p.Weight)
                .HasColumnType("decimal(5,2)")
                .IsRequired(true);
            
        }
    }
}
