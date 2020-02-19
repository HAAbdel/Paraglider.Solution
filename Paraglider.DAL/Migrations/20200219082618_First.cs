using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paraglider.DAL.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValide = table.Column<bool>(nullable: false),
                    CerttificatName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "ParagliderModels",
                columns: table => new
                {
                    ParagliderModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelType = table.Column<string>(nullable: false),
                    ModelName = table.Column<string>(nullable: false),
                    NumberOfHomologation = table.Column<string>(nullable: false),
                    DateOfHomologation = table.Column<DateTime>(type: "date", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MinimalWeight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MaximumWeight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParagliderModels", x => x.ParagliderModelId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    PilotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    CommuneName = table.Column<string>(nullable: false),
                    Orientation = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    SiteGeoCoordinate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "Traineeships",
                columns: table => new
                {
                    TraineeshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    Prize = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DateOfEnd = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "date", nullable: false),
                    CertificateId = table.Column<int>(nullable: true),
                    LevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineeships", x => x.TraineeshipId);
                    table.ForeignKey(
                        name: "FK_Traineeships_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Traineeships_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paragliders",
                columns: table => new
                {
                    ParagliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    DateOfService = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfUse = table.Column<DateTime>(type: "date", nullable: false),
                    FlightHours = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ParagliderModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragliders", x => x.ParagliderId);
                    table.ForeignKey(
                        name: "FK_Paragliders_ParagliderModels_ParagliderModelId",
                        column: x => x.ParagliderModelId,
                        principalTable: "ParagliderModels",
                        principalColumn: "ParagliderModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.PilotId);
                    table.ForeignKey(
                        name: "FK_Pilots_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandingSites",
                columns: table => new
                {
                    LandingSiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandingSiteName = table.Column<string>(nullable: false),
                    Approach = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingSites", x => x.LandingSiteId);
                    table.ForeignKey(
                        name: "FK_LandingSites_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LandingSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaunchingSites",
                columns: table => new
                {
                    LaunchingSiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    LaunchingSiteName = table.Column<string>(nullable: false),
                    Approach = table.Column<string>(nullable: true),
                    LevelId = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchingSites", x => x.LaunchingSiteId);
                    table.ForeignKey(
                        name: "FK_LaunchingSites_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaunchingSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "date", nullable: false),
                    FlightDuration = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IsValide = table.Column<bool>(nullable: false),
                    ParagliderId = table.Column<int>(nullable: false),
                    PilotId = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Paragliders_ParagliderId",
                        column: x => x.ParagliderId,
                        principalTable: "Paragliders",
                        principalColumn: "ParagliderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotCertificates",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    CertificateId = table.Column<int>(nullable: false),
                    DateOfSucc = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotCertificates", x => new { x.PilotId, x.CertificateId });
                    table.ForeignKey(
                        name: "FK_PilotCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PilotCertificates_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotMemberships",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    MembershipId = table.Column<int>(nullable: false),
                    DateOfPay = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotMemberships", x => new { x.PilotId, x.MembershipId });
                    table.ForeignKey(
                        name: "FK_PilotMemberships_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PilotMemberships_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotTraineeships",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    TraineeshipId = table.Column<int>(nullable: false),
                    IsTreacher = table.Column<bool>(nullable: false),
                    FollowExam = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotTraineeships", x => new { x.PilotId, x.TraineeshipId });
                    table.ForeignKey(
                        name: "FK_PilotTraineeships_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PilotTraineeships_Traineeships_TraineeshipId",
                        column: x => x.TraineeshipId,
                        principalTable: "Traineeships",
                        principalColumn: "TraineeshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "CertificateId", "CerttificatName", "IsValide" },
                values: new object[,]
                {
                    { 1, "No grade", true },
                    { 2, "Begginer", true },
                    { 3, "Medior", true },
                    { 4, "Advanced", true },
                    { 5, "Master", true }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "LevelId", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Only easy launching and landing sites with easy approatches only (Level 1)", false, "Begginer" },
                    { 2, "Can take two mediums launching and landing sites (Level 1-3)", false, "Medior" },
                    { 3, "Can take ALL kind of sites (Level 1-5) can teach easy sites (Level 1-2)", false, "Expert" },
                    { 4, "Can take ALL kind of sites and can teach on all kind of sites (Level 1-5)", false, "Master" }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MembershipId", "IsActive", "MembershipAmount" },
                values: new object[,]
                {
                    { 4, true, 220m },
                    { 3, false, 88.25m },
                    { 1, true, 128.2m },
                    { 2, true, 54.99m }
                });

            migrationBuilder.InsertData(
                table: "ParagliderModels",
                columns: new[] { "ParagliderModelId", "DateOfHomologation", "IsActive", "MaximumWeight", "MinimalWeight", "ModelName", "ModelType", "NumberOfHomologation", "Size" },
                values: new object[,]
                {
                    { 2, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 95m, 70m, "RAFALE", "SpeedFlying", "EN 961-1", 0m },
                    { 3, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 80m, 60m, "WHIZZ", "Hybride", "EN 926-2", 0m },
                    { 1, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 105m, 70m, "SPANTIK", "SoloWings", "EN 926", 0m }
                });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "PilotId", "Email", "FirstName", "IsActive", "LastName", "PhoneNumber", "RoleId", "Weight" },
                values: new object[] { 4, "L@S.be", "Lucky", true, "Str", "0466666666", null, 64m });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsActive", "PilotId", "RoleName" },
                values: new object[,]
                {
                    { 1, true, 1, "CEO" },
                    { 2, true, 2, "Manager" },
                    { 3, false, 3, "Secretary" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "SiteId", "CommuneName", "IsActive", "Orientation", "SiteGeoCoordinate", "ZipCode" },
                values: new object[,]
                {
                    { 3, "Prayon", true, "N-E", "50.575893°N 5.6566°E", "4870" },
                    { 1, "West Coo", true, "West", "50.39861°N 5.88778°E", "4970" },
                    { 2, "7 Meuses", true, "Sud", "50.354166667°N 4.86083333°E", "5170" },
                    { 4, "Beauraing", true, "N", "50.1130°N 5.0093°E", "5570" }
                });

            migrationBuilder.InsertData(
                table: "LandingSites",
                columns: new[] { "LandingSiteId", "Approach", "IsActive", "LandingSiteName", "LevelId", "SiteId" },
                values: new object[,]
                {
                    { 7, "", true, "Landung site 1", 1, 4 },
                    { 6, "", true, "Au Sommet", 1, 4 },
                    { 3, "", true, "Delta", 1, 1 },
                    { 5, "", true, "Main landing site", 1, 3 },
                    { 1, "", true, "Sommet", 1, 2 },
                    { 2, "", true, "West landing site", 1, 2 },
                    { 8, "", true, "Landing site 2", 1, 4 },
                    { 4, "", true, "Hallage", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "LaunchingSites",
                columns: new[] { "LaunchingSiteId", "Approach", "IsActive", "LaunchingSiteName", "LevelId", "SiteId" },
                values: new object[,]
                {
                    { 4, "", true, "Main Beauraing launching site", 1, 4 },
                    { 2, "", true, "Main West Coo launching site", 1, 1 },
                    { 1, "", true, "Main 7 Meuses launching site", 1, 2 },
                    { 3, "", true, "Main Prayon laucnhing site", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Paragliders",
                columns: new[] { "ParagliderId", "DateOfService", "DateOfUse", "FlightHours", "IsActive", "ParagliderModelId" },
                values: new object[,]
                {
                    { 3, new DateTime(2017, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 340m, true, 1 },
                    { 1, new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, true, 1 },
                    { 5, new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115m, true, 2 },
                    { 4, new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128m, true, 2 },
                    { 6, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, true, 3 },
                    { 2, new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "PilotCertificates",
                columns: new[] { "PilotId", "CertificateId", "DateOfSucc" },
                values: new object[] { 4, 4, new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PilotMemberships",
                columns: new[] { "PilotId", "MembershipId", "DateOfPay" },
                values: new object[] { 4, 1, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Pilots",
                columns: new[] { "PilotId", "Email", "FirstName", "IsActive", "LastName", "PhoneNumber", "RoleId", "Weight" },
                values: new object[,]
                {
                    { 2, "Y@b.com", "Yves", true, "Blavier", "0488888888", 1, 75m },
                    { 3, "A@t.be", "Antho", true, "Truc", "0477777777", 2, 58m },
                    { 1, "A@h.com", "Abdel", true, "Hnini", "0499999999", 3, 80m }
                });

            migrationBuilder.InsertData(
                table: "Traineeships",
                columns: new[] { "TraineeshipId", "CertificateId", "DateOfEnd", "DateOfStart", "IsActive", "LevelId", "Prize" },
                values: new object[,]
                {
                    { 6, null, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 199.99m },
                    { 4, null, new DateTime(2019, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 123.99m },
                    { 3, null, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 80.99m },
                    { 5, null, new DateTime(2018, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 49m },
                    { 2, null, new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 92m },
                    { 1, null, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 80.5m }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "FlightDate", "FlightDuration", "IsValide", "ParagliderId", "PilotId", "SiteId" },
                values: new object[,]
                {
                    { 2, new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, true, 4, 2, 2 },
                    { 3, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, true, 5, 3, 3 },
                    { 1, new DateTime(2018, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, true, 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "PilotCertificates",
                columns: new[] { "PilotId", "CertificateId", "DateOfSucc" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PilotMemberships",
                columns: new[] { "PilotId", "MembershipId", "DateOfPay" },
                values: new object[,]
                {
                    { 2, 4, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PilotTraineeships",
                columns: new[] { "PilotId", "TraineeshipId", "FollowExam", "IsTreacher" },
                values: new object[,]
                {
                    { 4, 3, false, true },
                    { 2, 2, false, true },
                    { 3, 6, true, false },
                    { 1, 1, false, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ParagliderId",
                table: "Flights",
                column: "ParagliderId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_SiteId",
                table: "Flights",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_LandingSites_LevelId",
                table: "LandingSites",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LandingSites_SiteId",
                table: "LandingSites",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_LaunchingSites_LevelId",
                table: "LaunchingSites",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LaunchingSites_SiteId",
                table: "LaunchingSites",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Paragliders_ParagliderModelId",
                table: "Paragliders",
                column: "ParagliderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotCertificates_CertificateId",
                table: "PilotCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotMemberships_MembershipId",
                table: "PilotMemberships",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_RoleId",
                table: "Pilots",
                column: "RoleId",
                unique: true,
                filter: "[RoleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PilotTraineeships_TraineeshipId",
                table: "PilotTraineeships",
                column: "TraineeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Traineeships_CertificateId",
                table: "Traineeships",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Traineeships_LevelId",
                table: "Traineeships",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "LandingSites");

            migrationBuilder.DropTable(
                name: "LaunchingSites");

            migrationBuilder.DropTable(
                name: "PilotCertificates");

            migrationBuilder.DropTable(
                name: "PilotMemberships");

            migrationBuilder.DropTable(
                name: "PilotTraineeships");

            migrationBuilder.DropTable(
                name: "Paragliders");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Traineeships");

            migrationBuilder.DropTable(
                name: "ParagliderModels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
