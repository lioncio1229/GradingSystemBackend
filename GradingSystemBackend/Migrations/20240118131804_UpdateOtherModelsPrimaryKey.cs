using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOtherModelsPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters_SemesterId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Strands_StrandId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SemesterId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StrandId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Strands",
                table: "Strands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StrandId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Strands");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Strands");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Semesters");

            migrationBuilder.AddColumn<string>(
                name: "SemesterKey",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrandCode",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Strands",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Semesters",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Strands",
                table: "Strands",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SemesterKey",
                table: "Subjects",
                column: "SemesterKey");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StrandCode",
                table: "Subjects",
                column: "StrandCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semesters_SemesterKey",
                table: "Subjects",
                column: "SemesterKey",
                principalTable: "Semesters",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Strands_StrandCode",
                table: "Subjects",
                column: "StrandCode",
                principalTable: "Strands",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters_SemesterKey",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Strands_StrandCode",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_SemesterKey",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StrandCode",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Strands",
                table: "Strands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "SemesterKey",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "StrandCode",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Strands");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Semesters");

            migrationBuilder.AddColumn<Guid>(
                name: "SemesterId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StrandId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Strands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Strands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Semesters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Strands",
                table: "Strands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SemesterId",
                table: "Subjects",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StrandId",
                table: "Subjects",
                column: "StrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semesters_SemesterId",
                table: "Subjects",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Strands_StrandId",
                table: "Subjects",
                column: "StrandId",
                principalTable: "Strands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
