using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class LaunchingSiteConfiguration : IEntityTypeConfiguration<LaunchingSite>
    {
        public void Configure(EntityTypeBuilder<LaunchingSite> builder)
        {
            builder.HasOne(sc => sc.Level).WithMany(sc => sc.LaunchingSites).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
