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
            modelBuilder.ApplyConfiguration(new ParagliderModelConfig());

            SeedingRoles(modelBuilder);
            SeedingPilots(modelBuilder);
            SeedingMembers(modelBuilder);
            SeedingLevels(modelBuilder);
            SeedingParagliders(modelBuilder);
            SeedingParagliderModels(modelBuilder);
            SeedingSites(modelBuilder);
            SeedingLaunchingSite(modelBuilder);
            SeedingLlandingSite(modelBuilder);
            SeedingCertificate(modelBuilder);
            SeedingTraineeship(modelBuilder);
            SeedingPilotCertificate(modelBuilder);
            SeedingPilotMembership(modelBuilder);
            SeedingPilotTraineeship(modelBuilder);
            SeedingFlights(modelBuilder);
        }
        public void SeedingRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = 1, RoleName = "CEO", IsActive = true},
                new Role() { RoleId = 2, RoleName = "Manager", IsActive = true},
                new Role() { RoleId = 3, RoleName = "Secretary", IsActive = false}
            );
        }
        public void SeedingPilots(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilot>().HasData(
                new Pilot() { PilotId = 1, FirstName = "Abdel", LastName = "Hnini", PhoneNumber = "0499999999", Email = "A@h.com", Weight = 80, RoleId = null, IsActive = true },
                new Pilot() { PilotId = 2, FirstName = "Yves", LastName = "Blavier", PhoneNumber = "0488888888", Email = "Y@b.com", Weight = 75, RoleId = 1, IsActive = true},
                new Pilot() { PilotId = 3, FirstName = "Antho", LastName = "Truc", PhoneNumber = "0477777777", Email = "A@t.be", Weight = 58, RoleId = 2, IsActive = true},
                new Pilot() { PilotId = 4, FirstName = "Lucky", LastName = "Str", PhoneNumber = "0466666666", Email = "L@S.be", Weight = 64, RoleId = null, IsActive = true}
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
                new Models.Paraglider() { ParagliderId = 2, DateOfService = new DateTime(2019, 9, 15), ParagliderModelId = 1, FlightHours = 30 , IsActive = true},
                new Models.Paraglider() { ParagliderId = 3, DateOfService = new DateTime(2017, 8, 1), ParagliderModelId = 1, FlightHours = 340, IsActive = true},
                new Models.Paraglider() { ParagliderId = 1, DateOfService = new DateTime(2019, 9, 15), ParagliderModelId = 1, FlightHours = 26 , IsActive = true},
                new Models.Paraglider() { ParagliderId = 4, DateOfService = new DateTime(2018, 7, 1), ParagliderModelId = 2, FlightHours = 128, IsActive = true},
                new Models.Paraglider() { ParagliderId = 5, DateOfService = new DateTime(2018, 7, 1), ParagliderModelId = 2, FlightHours = 115, IsActive = true},
                new Models.Paraglider() { ParagliderId = 6, DateOfService = new DateTime(2020, 1, 1), ParagliderModelId = 3, FlightHours = 0  , IsActive = true}
                );
        }
        public void SeedingParagliderModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParagliderModel>().HasData(
                new ParagliderModel() { ParagliderModelId = 2, ModelType = "SpeedFlying" ,ModelName = "RAFALE", NumberOfHomologation = "EN 961-1", DateOfHomologation = new DateTime(2018,02,18) , MinimalWeight = 70, MaximumWeight = 95, IsActive = true },
                new ParagliderModel() { ParagliderModelId = 3, ModelType = "Hybride" ,ModelName = "WHIZZ", NumberOfHomologation = "EN 926-2", DateOfHomologation = new DateTime(2018, 02, 18) , MinimalWeight = 60, MaximumWeight = 80, IsActive = true},
                new ParagliderModel() { ParagliderModelId = 1, ModelType = "SoloWings" ,ModelName = "SPANTIK", NumberOfHomologation = "EN 926", DateOfHomologation = new DateTime(2018, 02, 18), MinimalWeight = 70, MaximumWeight = 105, IsActive = true}
                );
        }
        public void SeedingSites(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().HasData(
                new Site() { SiteId = 1, CommuneName = "West Coo" , ZipCode = "4970", SiteGeoCoordinate = "50.39861°N 5.88778°E" , Orientation = "West", IsActive = true},
                new Site() { SiteId = 2, CommuneName = "7 Meuses" , ZipCode = "5170", SiteGeoCoordinate = "50.354166667°N 4.86083333°E" , Orientation = "Sud",IsActive = true},
                new Site() { SiteId = 3, CommuneName = "Prayon", ZipCode = "4870", SiteGeoCoordinate = "50.575893°N 5.6566°E" , Orientation = "N-E", IsActive = true},
                new Site() { SiteId = 4, CommuneName = "Beauraing", ZipCode = "5570", SiteGeoCoordinate = "50.1130°N 5.0093°E", Orientation = "N", IsActive = true}
                );
        }
        public void SeedingLaunchingSite(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaunchingSite>().HasData(
                new LaunchingSite() { LaunchingSiteId = 1, LaunchingSiteName = "Main 7 Meuses launching site" , Approach = "" , SiteId = 2, LevelId = 1 }, 
                new LaunchingSite() { LaunchingSiteId = 2, LaunchingSiteName = "Main West Coo launching site" , Approach = "" , SiteId = 1, LevelId = 1 },
                new LaunchingSite() { LaunchingSiteId = 3, LaunchingSiteName = "Main Prayon laucnhing site" , Approach = "" , SiteId = 3, LevelId = 1 }, 
                new LaunchingSite() { LaunchingSiteId = 4, LaunchingSiteName = "Main Beauraing launching site", Approach = ""  , SiteId = 4, LevelId = 1 } 
                );
        }
        public void SeedingLlandingSite(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LandingSite>().HasData(
                new LandingSite() { LandingSiteId = 1, LandingSiteName = "Sommet" , Approach = "", SiteId = 2 , LevelId = 1},
                new LandingSite() { LandingSiteId = 2, LandingSiteName = "West landing site" , Approach = "", SiteId = 2, LevelId = 1 },
                new LandingSite() { LandingSiteId = 3, LandingSiteName = "Delta" , Approach = "", SiteId = 1, LevelId = 1 },
                new LandingSite() { LandingSiteId = 4, LandingSiteName = "Hallage" , Approach = "", SiteId = 1, LevelId = 1 },
                new LandingSite() { LandingSiteId = 5, LandingSiteName = "Main landing site", Approach = "", SiteId = 3, LevelId = 1 },
                new LandingSite() { LandingSiteId = 6, LandingSiteName = "Au Sommet", Approach = "", SiteId = 4, LevelId = 1 },
                new LandingSite() { LandingSiteId = 7, LandingSiteName = "Landung site 1", Approach = "", SiteId = 4, LevelId = 1 },
                new LandingSite() { LandingSiteId = 8, LandingSiteName = "Landing site 2", Approach = "", SiteId = 4, LevelId = 1 }
                );
        }
        public void SeedingCertificate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>().HasData(
                new Certificate() { CertificateId = 1, CerttificatName = "No grade", IsValide =true},
                new Certificate() { CertificateId = 2, CerttificatName = "Begginer", IsValide = true },
                new Certificate() { CertificateId = 3, CerttificatName = "Medior", IsValide = true },
                new Certificate() { CertificateId = 4, CerttificatName = "Advanced", IsValide = true },
                new Certificate() { CertificateId = 5, CerttificatName = "Master", IsValide = true }
                );
    }
        public void SeedingTraineeship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Traineeship>().HasData(
                new  Traineeship() { TraineeshipId = 1, Prize = (decimal)80.50, DateOfEnd = new DateTime(2019, 12, 20) , DateOfStart = new DateTime(2019, 12, 18) , CertificateId = null, LevelId = 1, IsActive = true},
                new  Traineeship() { TraineeshipId = 2, Prize = 92, DateOfEnd = new DateTime(2019, 11, 30) , DateOfStart = new DateTime(2019, 10, 30) , CertificateId = null, LevelId = 2, IsActive = true },
                new  Traineeship() { TraineeshipId = 3, Prize = (decimal)80.99, DateOfEnd = new DateTime(2020, 3,18) , DateOfStart = new DateTime(2020, 1, 27) , CertificateId = null, LevelId = 3, IsActive = true },
                new  Traineeship() { TraineeshipId = 4, Prize = (decimal)123.99, DateOfEnd = new DateTime(2019, 12, 8) , DateOfStart = new DateTime(2019, 9, 16) , CertificateId = null, LevelId = 3, IsActive = true },
                new  Traineeship() { TraineeshipId = 5, Prize = 49, DateOfEnd = new DateTime(2018, 8, 31) , DateOfStart = new DateTime(2018, 8, 1) , CertificateId = null, LevelId = 2, IsActive = true },
                new Traineeship() { TraineeshipId = 6, Prize = (decimal)199.99, DateOfEnd = new DateTime(2018, 4, 12), DateOfStart = new DateTime(2018, 1, 8), CertificateId = null, LevelId = 4, IsActive = true }
                );
        }
        public void SeedingPilotCertificate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotCertificate>().HasData(
                new PilotCertificate() { PilotId = 1, DateOfSucc = new DateTime(2018, 1, 1), CertificateId = 1},
                new PilotCertificate() { PilotId = 2, DateOfSucc = new DateTime(2018, 2, 20), CertificateId = 2},
                new PilotCertificate() { PilotId = 3, DateOfSucc = new DateTime(2019, 9, 18), CertificateId = 3},
                new PilotCertificate() { PilotId = 4, DateOfSucc = new DateTime(2019, 5, 2), CertificateId = 4}
                );
        }
        public void SeedingPilotMembership(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PilotMembership>().HasData(
                new PilotMembership () { PilotId = 1, DateOfPay = new DateTime(2018, 2,18), MembershipId = 2},
                new PilotMembership () { PilotId = 2, DateOfPay = new DateTime(2018, 2, 18), MembershipId = 4},
                new PilotMembership () { PilotId = 3, DateOfPay = new DateTime(2018, 2, 18), MembershipId = 3},
                new PilotMembership() { PilotId = 4, DateOfPay = new DateTime(2018, 2, 18), MembershipId = 1}
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
        public void SeedingFlights(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(
                new Flight() { FlightId = 1,IsValide = true,ParagliderId = 1,PilotId = 1,FlightDate = new DateTime(2018, 9, 2),FlightDuration = 1,SiteId = 1},
                new Flight() { FlightId = 2,IsValide = true,ParagliderId = 4,PilotId = 2,FlightDate = new DateTime(2018, 9, 10),FlightDuration = 2,SiteId = 2},
                new Flight() { FlightId = 3, IsValide = true, ParagliderId = 5,PilotId = 3,FlightDate = new DateTime(2019, 10, 1),FlightDuration = 2,SiteId = 3}
                );
        }
    }
}
