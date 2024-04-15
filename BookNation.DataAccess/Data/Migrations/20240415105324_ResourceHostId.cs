using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ResourceHostId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceHost",
                table: "Resources");

            migrationBuilder.AddColumn<int>(
                name: "ResourceHostId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceHostId",
                table: "Resources");

            migrationBuilder.AddColumn<string>(
                name: "ResourceHost",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
