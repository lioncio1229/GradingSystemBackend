using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_FacultyId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Subjects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_FacultyId",
                table: "Subjects",
                newName: "IX_Subjects_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_UserId",
                table: "Subjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_UserId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Subjects",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_UserId",
                table: "Subjects",
                newName: "IX_Subjects_FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_FacultyId",
                table: "Subjects",
                column: "FacultyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
