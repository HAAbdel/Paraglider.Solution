using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paraglider.DAL.Migrations
{
    public partial class ModelingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DateOfStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineeship", x => x.TraineeshipId);
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
                name: "PilotTraineeship",
                columns: table => new
                {
                    PilotId = table.Column<int>(nullable: false),
                    TraineeshipId = table.Column<int>(nullable: false),
                    FollowExam = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotTraineeship", x => new { x.PilotId, x.TraineeshipId });
                    table.ForeignKey(
                        name: "FK_PilotTraineeship_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "PilotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotTraineeship_Traineeship_TraineeshipId",
                        column: x => x.TraineeshipId,
                        principalTable: "Traineeship",
                        principalColumn: "TraineeshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PilotMemberships_MembershipId",
                table: "PilotMemberships",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotTraineeship_TraineeshipId",
                table: "PilotTraineeship",
                column: "TraineeshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PilotId",
                table: "Roles",
                column: "PilotId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotMemberships");

            migrationBuilder.DropTable(
                name: "PilotTraineeship");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Traineeship");

            migrationBuilder.DropTable(
                name: "Pilots");
        }
    }
}
