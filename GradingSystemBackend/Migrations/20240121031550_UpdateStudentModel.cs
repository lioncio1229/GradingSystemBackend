using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters_SemesterKey",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Strands_StrandCode",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelKey",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Strand",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "YearLevel",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "YearLevelKey",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StrandCode",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SemesterKey",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "SemesterKey",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrandCode",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearLevelKey",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SemesterKey",
                table: "Students",
                column: "SemesterKey");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StrandCode",
                table: "Students",
                column: "StrandCode");

            migrationBuilder.CreateIndex(
                name: "IX_Students_YearLevelKey",
                table: "Students",
                column: "YearLevelKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semesters_SemesterKey",
                table: "Students",
                column: "SemesterKey",
                principalTable: "Semesters",
                principalColumn: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Strands_StrandCode",
                table: "Students",
                column: "StrandCode",
                principalTable: "Strands",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_YearLevels_YearLevelKey",
                table: "Students",
                column: "YearLevelKey",
                principalTable: "YearLevels",
                principalColumn: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Semesters_SemesterKey",
                table: "Subjects",
                column: "SemesterKey",
                principalTable: "Semesters",
                principalColumn: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Strands_StrandCode",
                table: "Subjects",
                column: "StrandCode",
                principalTable: "Strands",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelKey",
                table: "Subjects",
                column: "YearLevelKey",
                principalTable: "YearLevels",
                principalColumn: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semesters_SemesterKey",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Strands_StrandCode",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_YearLevels_YearLevelKey",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Semesters_SemesterKey",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Strands_StrandCode",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelKey",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Students_SemesterKey",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_StrandCode",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_YearLevelKey",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SemesterKey",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StrandCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "YearLevelKey",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "YearLevelKey",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StrandCode",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SemesterKey",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Strand",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearLevel",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_YearLevels_YearLevelKey",
                table: "Subjects",
                column: "YearLevelKey",
                principalTable: "YearLevels",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
