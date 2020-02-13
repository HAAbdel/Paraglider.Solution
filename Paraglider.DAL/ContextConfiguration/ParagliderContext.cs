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
            modelBuilder.ApplyConfiguration(new PilotCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
            modelBuilder.ApplyConfiguration(new TraineeshipConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new LaunchingSiteConfiguration());
            modelBuilder.ApplyConfiguration(new LandingSiteConfiguration());
            modelBuilder.ApplyConfiguration(new ParagliderConfig());
        }
        public DbSet<PilotCertificate> PilotCertificates { get; set; }
        public DbSet<PilotTraineeship> PilotTraineeships { get; set; }
        public DbSet<PilotMembership> PilotMemberships { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships {get;set;}
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Models.Paraglider> Paragliders{ get; set; }
        public DbSet<ParagliderModel> ParagliderModels { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<LandingSite> LandingSites { get; set; }
        public DbSet<LaunchingSite> LaunchingSites { get; set; }
        public DbSet<Traineeship> Traineeships { get; set; }
        public DbSet<Level> Levels { get; set; }

    }
}
