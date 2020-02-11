using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.ContextConfiguration.ModelsConfiguration
{
    class PilotMembershipConfiguration : IEntityTypeConfiguration<PilotMembership>
    {
        public void Configure(EntityTypeBuilder<PilotMembership> builder)
        {
            builder.HasKey(sc => new { sc.PilotId, sc.MembershipId });
            builder.HasOne(sc => sc.Membership).WithMany(p => p.PilotMemberships).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
