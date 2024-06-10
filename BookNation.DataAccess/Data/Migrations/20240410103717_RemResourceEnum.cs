using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemResourceEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppResource_Users_AppUserId",
                table: "AppResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppResource",
                table: "AppResource");

            migrationBuilder.RenameTable(
                name: "AppResource",
                newName: "Resources");

            migrationBuilder.RenameIndex(
                name: "IX_AppResource_AppUserId",
                table: "Resources",
                newName: "IX_Resources_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceType",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Users_AppUserId",
                table: "Resources",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Users_AppUserId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "AppResource");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_AppUserId",
                table: "AppResource",
                newName: "IX_AppResource_AppUserId");

            migrationBuilder.AlterColumn<int>(
                name: "ResourceType",
                table: "AppResource",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppResource",
                table: "AppResource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppResource_Users_AppUserId",
                table: "AppResource",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
