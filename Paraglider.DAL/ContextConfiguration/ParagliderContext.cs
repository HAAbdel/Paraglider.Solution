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
            modelBuilder.Entity<PilotMembership>().HasOne(sc => sc.Membership).WithMany(p => p.PilotMemberships).IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PilotTraineeship>().HasKey(sc => new { sc.PilotId, sc.TraineeshipId });
            modelBuilder.Entity<PilotTraineeship>().HasOne(sc => sc.Traineeship).WithMany(p => p.PilotTraineeships).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships {get;set;}
        public DbSet<PilotMembership> PilotMemberships { get; set; }
    }
}
