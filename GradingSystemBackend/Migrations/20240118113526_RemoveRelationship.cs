using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrandUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrandUser",
                columns: table => new
                {
                    StrandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrandUser", x => new { x.StrandsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_StrandUser_Strands_StrandsId",
                        column: x => x.StrandsId,
                        principalTable: "Strands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StrandUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrandUser_UsersId",
                table: "StrandUser",
                column: "UsersId");
        }
    }
}
