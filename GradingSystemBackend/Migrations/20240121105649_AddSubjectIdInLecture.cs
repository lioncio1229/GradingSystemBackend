using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectIdInLecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Subjects_SubjectId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Lectures",
                newName: "SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_Lectures_SubjectId",
                table: "Lectures",
                newName: "IX_Lectures_SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Subjects_SubjectId1",
                table: "Lectures",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Subjects_SubjectId1",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "Lectures",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Lectures_SubjectId1",
                table: "Lectures",
                newName: "IX_Lectures_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Subjects_SubjectId",
                table: "Lectures",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
