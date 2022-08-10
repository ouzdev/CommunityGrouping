using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommunityGrouping.Data.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_ApplicationUsers_ApplicationUserId",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_CommunityGroups_CommunityGroupId",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Occupation_OccupationId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_ApplicationUserId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_CommunityGroupId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_OccupationId",
                table: "ApplicationUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupation",
                table: "Occupation");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "CommunityGroupId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "Occupation",
                newName: "Occupations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupations",
                table: "Occupations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: false),
                    OccupationId = table.Column<int>(type: "integer", nullable: false),
                    CommunityGroupId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_CommunityGroups_CommunityGroupId",
                        column: x => x.CommunityGroupId,
                        principalTable: "CommunityGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ApplicationUserId",
                table: "People",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CommunityGroupId",
                table: "People",
                column: "CommunityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_People_OccupationId",
                table: "People",
                column: "OccupationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupations",
                table: "Occupations");

            migrationBuilder.RenameTable(
                name: "Occupations",
                newName: "Occupation");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicationUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "ApplicationUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommunityGroupId",
                table: "ApplicationUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "ApplicationUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OccupationId",
                table: "ApplicationUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ApplicationUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupation",
                table: "Occupation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_ApplicationUserId",
                table: "ApplicationUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CommunityGroupId",
                table: "ApplicationUsers",
                column: "CommunityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_OccupationId",
                table: "ApplicationUsers",
                column: "OccupationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_ApplicationUsers_ApplicationUserId",
                table: "ApplicationUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_CommunityGroups_CommunityGroupId",
                table: "ApplicationUsers",
                column: "CommunityGroupId",
                principalTable: "CommunityGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Occupation_OccupationId",
                table: "ApplicationUsers",
                column: "OccupationId",
                principalTable: "Occupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
