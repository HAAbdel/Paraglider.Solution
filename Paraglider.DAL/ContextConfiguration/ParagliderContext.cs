using Microsoft.EntityFrameworkCore;
using Paraglider.DAL.ContextConfiguration.ModelsConfiguration;
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
            modelBuilder.ApplyConfiguration(new PilotMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new PilotTraineeshipConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());
        }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships {get;set;}
        public DbSet<PilotMembership> PilotMemberships { get; set; }
    }
}
