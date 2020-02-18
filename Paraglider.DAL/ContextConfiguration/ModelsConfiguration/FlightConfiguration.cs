using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasOne(p => p.Site)
                .WithMany(p => p.Flights)
                .HasForeignKey(p => p.SiteId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Pilot)
                .WithMany(p => p.Flights)
                .HasForeignKey(p => p.PilotId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(sc => sc.FlightDate).HasColumnType("date");
            builder.Property(sc => sc.FlightDuration).HasColumnType("decimal(5,2)");
        }
    }
}
