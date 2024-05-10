using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Users_AppUserId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AppUserId",
                table: "Resources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Resources_AppUserId",
                table: "Resources",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Users_AppUserId",
                table: "Resources",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
