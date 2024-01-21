using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixManyToManyInGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubjectId",
                table: "Students",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SubjectId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Students");
        }
    }
}
