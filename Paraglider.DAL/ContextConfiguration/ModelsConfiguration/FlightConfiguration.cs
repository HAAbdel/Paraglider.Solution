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
            builder.HasOne(sc => sc.LandingSite).WithMany(s => s.Flights).HasForeignKey(s => s.LandingSiteId);
            builder.HasOne(sc => sc.LaunchingSite).WithMany(s => s.Flights).HasForeignKey(s => s.LaunchingSiteId);
        }
    }
}
