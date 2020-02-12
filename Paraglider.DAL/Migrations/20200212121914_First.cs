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
                    CerttificatName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "Paraglinders",
                columns: table => new
                {
                    ParaglinderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: false),
                    DateOfService = table.Column<DateTime>(nullable: false),
                    DateOfUse = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paraglinders", x => x.ParaglinderId);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(3,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.PilotId);
                });

            migrationBuilder.CreateTable(
                name: "Traineeship",
                columns: table => new
                {
                    TraineeshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prize = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DateOfEnd = table.Column<DateTime>(nullable: false),
                    DateOfStart = table.Column<DateTime>(nullable: false),
                    CertificateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineeship", x => x.TraineeshipId);
                    table.ForeignKey(
                        name: "FK_Traineeship_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParaglinderModels",
                columns: table => new
                {
                    ParaglinderModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfHomologation = table.Column<int>(nullable: false),
                    DateOfHomologation = table.Column<DateTime>(nullable: false),
                    Size = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    MinimalWeight = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    MaximumWeight = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    ParaglinderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaglinderModels", x => x.ParaglinderModelId);
                    table.ForeignKey(
                        name: "FK_ParaglinderModels_Paraglinders_ParaglinderId",
                        column: x => x.ParaglinderId,
                        principalTable: "Paraglinders",
                        principalColumn: "ParaglinderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PilotCertificates",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    CertificateId = table.Column<int>(nullable: false),
                    DateOfSucc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotCertificates", x => new { x.CertificateId, x.PilotId });
                    table.ForeignKey(
                        name: "FK_PilotCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotCertificates_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PilotMemberships",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    MembershipId = table.Column<int>(nullable: false),
                    DateOfPay = table.Column<DateTime>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true),
                    PilotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PilotTraineeships",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    TraineeshipId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotTraineeships_Traineeship_TraineeshipId",
                        column: x => x.TraineeshipId,
                        principalTable: "Traineeship",
                        principalColumn: "TraineeshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParaglinderModels_ParaglinderId",
                table: "ParaglinderModels",
                column: "ParaglinderId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotCertificates_PilotId",
                table: "PilotCertificates",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotMemberships_MembershipId",
                table: "PilotMemberships",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotTraineeships_TraineeshipId",
                table: "PilotTraineeships",
                column: "TraineeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PilotId",
                table: "Roles",
                column: "PilotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Traineeship_CertificateId",
                table: "Traineeship",
                column: "CertificateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParaglinderModels");

            migrationBuilder.DropTable(
                name: "PilotCertificates");

            migrationBuilder.DropTable(
                name: "PilotMemberships");

            migrationBuilder.DropTable(
                name: "PilotTraineeships");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Paraglinders");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Traineeship");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
