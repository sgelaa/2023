using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicableFieldNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ApplicableField_ApplicableFieldId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ApplicableFieldId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicableField",
                table: "ApplicableField");

            migrationBuilder.DropColumn(
                name: "ApplicableFieldId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ApplicableField",
                newName: "ApplicableFields");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ApplicableFields",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicableFields",
                table: "ApplicableFields",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicableFields_ProductId",
                table: "ApplicableFields",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicableFields_Products_ProductId",
                table: "ApplicableFields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicableFields_Products_ProductId",
                table: "ApplicableFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicableFields",
                table: "ApplicableFields");

            migrationBuilder.DropIndex(
                name: "IX_ApplicableFields_ProductId",
                table: "ApplicableFields");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ApplicableFields");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ApplicableFields",
                newName: "ApplicableField");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicableFieldId",
                table: "Product",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicableField",
                table: "ApplicableField",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
