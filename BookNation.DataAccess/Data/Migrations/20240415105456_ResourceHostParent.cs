using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class ResourceHostParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceHost",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceHost",
                table: "Resources");
        }
    }
}
