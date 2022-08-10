using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommunityGrouping.Data.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicationUsers",
                type: "integer",
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

            migrationBuilder.CreateTable(
                name: "CommunityGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CommunityGroups");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_ApplicationUserId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_CommunityGroupId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_OccupationId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
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
        }
    }
}
