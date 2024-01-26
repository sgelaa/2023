using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicableField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicableFieldId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicableField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicableField", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ApplicableFieldId",
                table: "Product",
                column: "ApplicableFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ApplicableField_ApplicableFieldId",
                table: "Product",
                column: "ApplicableFieldId",
                principalTable: "ApplicableField",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ApplicableField_ApplicableFieldId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ApplicableField");

            migrationBuilder.DropIndex(
                name: "IX_Product_ApplicableFieldId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApplicableFieldId",
                table: "Product");
        }
    }
}
