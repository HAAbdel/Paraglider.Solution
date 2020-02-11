using Microsoft.EntityFrameworkCore;
using Paraglider.DAL.Models;
using System;

namespace Paraglider.DAL
{
    public class ParagliderContext : DbContext
    {
        public ParagliderContext(DbContextOptions<ParagliderContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotMembership>().HasKey(sc => new { sc.PilotId, sc.MembershipId });
            modelBuilder.Entity<PilotTraineeship>().HasKey(sc => new { sc.PilotId, sc.TraineeshipId });
        }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships {get;set;}
        public DbSet<PilotMembership> PilotMemberships { get; set; }
    }
}
