using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateYearLevelModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearLevels",
                table: "YearLevels");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_YearLevelId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "YearLevels");

            migrationBuilder.DropColumn(
                name: "YearLevelId",
                table: "Subjects");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "YearLevels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearLevelKey",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearLevels",
                table: "YearLevels",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_YearLevelKey",
                table: "Subjects",
                column: "YearLevelKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelKey",
                table: "Subjects",
                column: "YearLevelKey",
                principalTable: "YearLevels",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelKey",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearLevels",
                table: "YearLevels");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_YearLevelKey",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "YearLevels");

            migrationBuilder.DropColumn(
                name: "YearLevelKey",
                table: "Subjects");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "YearLevels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "YearLevelId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearLevels",
                table: "YearLevels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_YearLevelId",
                table: "Subjects",
                column: "YearLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelId",
                table: "Subjects",
                column: "YearLevelId",
                principalTable: "YearLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
