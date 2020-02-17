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
        public DbSet<PilotCertificate> PilotCertificates { get; set; }
        public DbSet<PilotTraineeship> PilotTraineeships { get; set; }
        public DbSet<PilotMembership> PilotMemberships { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Models.Paraglider> Paragliders { get; set; }
        public DbSet<ParagliderModel> ParagliderModels { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<LandingSite> LandingSites { get; set; }
        public DbSet<LaunchingSite> LaunchingSites { get; set; }
        public DbSet<Traineeship> Traineeships { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Site> Sites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PilotMembershipConfiguration());
            modelBuilder.ApplyConfiguration(new PilotTraineeshipConfiguration());
            modelBuilder.ApplyConfiguration(new PilotCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new TraineeshipConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new LaunchingSiteConfiguration());
            modelBuilder.ApplyConfiguration(new LandingSiteConfiguration());
            modelBuilder.ApplyConfiguration(new ParagliderConfig());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());

            SeedingRoles(modelBuilder);
            SeedingPilots(modelBuilder);
           
        }
        public void SeedingRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = 1, RoleName = "No Role", IsActive = true},
                new Role() { RoleId = 2, RoleName = "CEO", IsActive = true},
                new Role() { RoleId = 3, RoleName = "Manager", IsActive = true},
                new Role() { RoleId = 4, RoleName = "Secretary", IsActive = false}
            );
        }
        public void SeedingPilots(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilot>().HasData(
                new Pilot() { PilotId = 1, FirstName = "Abdel", LastName = "Hnini", PhoneNumber = "0499999999", Email = "A@h.com", Weight = 80, RoleId = 1, IsActive = true },
                new Pilot() { PilotId = 2, FirstName = "Yves", LastName = "Blavier", PhoneNumber = "0488888888", Email = "Y@b.com", Weight = 75, RoleId = 2, IsActive = true},
                new Pilot() { PilotId = 3, FirstName = "Antho", LastName = "Truc", PhoneNumber = "0477777777", Email = "A@t.be", Weight = 58, RoleId = 3, IsActive = true},
                new Pilot() { PilotId = 4, FirstName = "Lucky", LastName = "Str", PhoneNumber = "0466666666", Email = "L@S.be", Weight = 64, RoleId = 1, IsActive = true}
                );
        }
        public void SeedingMembers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().HasData(
                new Membership() { MembershipId = 1, MembershipAmount = (decimal)128.2, IsActive = true },
                new Membership() { MembershipId = 2, MembershipAmount = (decimal)54.99, IsActive = true},
                new Membership() { MembershipId = 3, MembershipAmount = (decimal)88.25, IsActive = false},
                new Membership() { MembershipId = 4, MembershipAmount = 220, IsActive = true}
            );
        }
        public void SeedingLevels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
                new Level() { LevelId = 1, Name = "Begginer", Description = "Only easy launching and landing sites with easy approatches only (Level 1)"},
                new Level() { LevelId = 2, Name = "Medior", Description = "Can take two mediums launching and landing sites (Level 1-3)"},
                new Level() { LevelId = 3, Name = "Expert", Description = "Can take ALL kind of sites (Level 1-5) can teach easy sites (Level 1-2)"},
                new Level() { LevelId = 4, Name = "Master", Description = "Can take ALL kind of sites and can teach on all kind of sites (Level 1-5)"}
                );
        }
        public void SeedingParagliders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Paraglider>().HasData(
                new Models.Paraglider() { ParagliderId = 2, DateOfService = new DateTime(2019,09,15), ParagliderModelId = 1, FlightHours = 30},
                new Models.Paraglider() { ParagliderId = 3, DateOfService = new DateTime(2017,08,01), ParagliderModelId = 1, FlightHours = 340},
                new Models.Paraglider() { ParagliderId = 1, DateOfService = new DateTime(2019,09,15), ParagliderModelId = 1, FlightHours = 26},
                new Models.Paraglider() { ParagliderId = 4, DateOfService = new DateTime(2018,07,01), ParagliderModelId = 2, FlightHours = 128},
                new Models.Paraglider() { ParagliderId = 5, DateOfService = new DateTime(2018,07,01), ParagliderModelId = 2, FlightHours = 115},
                new Models.Paraglider() { ParagliderId = 6, DateOfService = new DateTime(2020,01,01), ParagliderModelId = 3, FlightHours = 0}
                );
        }
        public void SeedingParagliderModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParagliderModel>().HasData(
                new ParagliderModel() { ParagliderModelId = 2, ModelType = "SpeedFlying" ,ModelName = "RAFALE", NumberOfHomologation = "EN 961-1", DateOfHomologation = new DateTime() , MinimalWeight = 70, MaximumWeight = 95},
                new ParagliderModel() { ParagliderModelId = 3, ModelType = "Hybride" ,ModelName = "WHIZZ", NumberOfHomologation = "EN 926-2", DateOfHomologation = new DateTime() , MinimalWeight = 60, MaximumWeight = 80},
                new ParagliderModel() { ParagliderModelId = 1, ModelType = "SoloWings" ,ModelName = "SPANTIK", NumberOfHomologation = "EN 926", DateOfHomologation = new DateTime(), MinimalWeight = 70, MaximumWeight = 105}
                );
        }
        public void SeedingSites(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().HasData(
                new Site() { SiteId = 1, CommuneName = "West Coo" , ZipCode = "4970", SiteGeoCoordinate = "50.39861°N 5.88778°E" , Orientation = "West"},
                new Site() { SiteId = 2, CommuneName = "7 Meuses" , ZipCode = "5170", SiteGeoCoordinate = "50.354166667°N 4.86083333°E" , Orientation = "Sud" },
                new Site() { SiteId = 3, CommuneName = "Prayon", ZipCode = "4870", SiteGeoCoordinate = "50.575893°N 5.6566°E" , Orientation = "N-E"},
                new Site() { SiteId = 4, CommuneName = "Beauraing", ZipCode = "5570", SiteGeoCoordinate = "50.1130°N 5.0093°E", Orientation = "N"}
                );
        }
        public void SeedingLaunchingSite(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaunchingSite>().HasData(
                new LaunchingSite() { LaunchingSiteId = 1, LaunchingSiteName = "Main 7 Meuses launching site" , Approach = "" , SiteId = 2}, 
                new LaunchingSite() { LaunchingSiteId = 2, LaunchingSiteName = "Main West Coo launching site" , Approach = "" , SiteId = 1},
                new LaunchingSite() { LaunchingSiteId = 3, LaunchingSiteName = "Main Prayon laucnhing site" , Approach = "" , SiteId = 3}, 
                new LaunchingSite() { LaunchingSiteId = 4, LaunchingSiteName = "Main Beauraing launching site", Approach = ""  , SiteId = 4} 
                );
        }
        public void SeedingLlandingSite(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LandingSite>().HasData(
                new LandingSite() { LandingSiteId = 1, LandingSiteName = "Sommet" , Approach = "", SiteId = 2 },
                new LandingSite() { LandingSiteId = 2, LandingSiteName = "West landing site" , Approach = "", SiteId = 2 },
                new LandingSite() { LandingSiteId = 3, LandingSiteName = "Delta" , Approach = "", SiteId = 1 },
                new LandingSite() { LandingSiteId = 4, LandingSiteName = "Hallage" , Approach = "", SiteId = 1 },
                new LandingSite() { LandingSiteId = 5, LandingSiteName = "Main landing site", Approach = "", SiteId = 3 },
                new LandingSite() { LandingSiteId = 5, LandingSiteName = "Au Sommet", Approach = "", SiteId = 4 },
                new LandingSite() { LandingSiteId = 5, LandingSiteName = "Landung site 1", Approach = "", SiteId = 4 },
                new LandingSite() { LandingSiteId = 5, LandingSiteName = "Landing site 2", Approach = "", SiteId = 4}
                );
        }
        public void SeedingCertificate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>().HasData(
                new Certificate() { CertificateId = 1, CerttificatName = "No grade"},
                new Certificate() { CertificateId = 2, CerttificatName = "Begginer"},
                new Certificate() { CertificateId = 3, CerttificatName = "Medior"},
                new Certificate() { CertificateId = 4, CerttificatName = "Advanced"},
                new Certificate() { CertificateId = 5, CerttificatName = "Master"}
                );
    }
        public void SeedingTraineeship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Traineeship>().HasData(
                new  Traineeship() { TraineeshipId = 1, Prize = (decimal)80.50, DateOfEnd = new DateTime(2019,12,20) , DateOfStart = new DateTime(2019,12,18) , CertificateId = null, LevelId = 1},
                new  Traineeship() { TraineeshipId = 2, Prize = 92, DateOfEnd = new DateTime(2019,11,30) , DateOfStart = new DateTime(2019,10,30) , CertificateId = null, LevelId = 2},
                new  Traineeship() { TraineeshipId = 3, Prize = (decimal)80.99, DateOfEnd = new DateTime(2020,03,18) , DateOfStart = new DateTime(2020,01,27) , CertificateId = null, LevelId = 3},
                new  Traineeship() { TraineeshipId = 4, Prize = (decimal)123.99, DateOfEnd = new DateTime(2019,12,08) , DateOfStart = new DateTime(2019,09,16) , CertificateId = null, LevelId = 3},
                new  Traineeship() { TraineeshipId = 5, Prize = 49, DateOfEnd = new DateTime(2018,08,31) , DateOfStart = new DateTime(2018,08,01) , CertificateId = null, LevelId = 2},
                new Traineeship() { TraineeshipId = 6, Prize = (decimal)199.99, DateOfEnd = new DateTime(2018,04,12), DateOfStart = new DateTime(2018,01,08), CertificateId = null, LevelId = 4}
                );
        }
        public void SeedingPilotCertificate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotCertificate>().HasData(
                new PilotCertificate() { PilotId = 1, DateOfSucc = new DateTime(2018, 1, 1), CertificateId = 1},
                new PilotCertificate() { PilotId = 2, DateOfSucc = new DateTime(2018, 2, 20), CertificateId = 2},
                new PilotCertificate() { PilotId = 3, DateOfSucc = new DateTime(2019, 09, 18), CertificateId = 3},
                new PilotCertificate() { PilotId = 4, DateOfSucc = new DateTime(2019, 05, 02), CertificateId = 4}
                );
        }
        public void SeedingPilotMembership(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotMembership>().HasData(
                new PilotMembership () { PilotId = 1, DateOfPay = new DateTime(), MembershipId = 2},
                new PilotMembership () { PilotId = 2, DateOfPay = new DateTime(), MembershipId = 4},
                new PilotMembership () { PilotId = 3, DateOfPay = new DateTime(), MembershipId = 3},
                new PilotMembership() { PilotId = 4, DateOfPay = new DateTime(), MembershipId = 1}
                );
        }
        public void SeedingPilotTraineeship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotTraineeship>().HasData(
                new PilotTraineeship() { PilotId = 1, IsTreacher = false,FollowExam = false,TraineeshipId = 1},
                new PilotTraineeship() { PilotId = 2, IsTreacher = true,FollowExam = false,TraineeshipId = 2},
                new PilotTraineeship() { PilotId = 3, IsTreacher = false,FollowExam = true,TraineeshipId = 6},
                new PilotTraineeship() { PilotId = 4, IsTreacher = true, FollowExam = false, TraineeshipId = 3}
                );
        }
    }
}
