using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookNation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicableFields_Products_ProductId",
                table: "ApplicableFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Author_Products_ProductId",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Author_ProductId",
                table: "Authors",
                newName: "IX_Authors_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ApplicableFields",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Authors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicableFields_Products_ProductId",
                table: "ApplicableFields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Products_ProductId",
                table: "Authors",
                column: "ProductId",
                principalTable: "Products",
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
                name: "FK_Authors_Products_ProductId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_ProductId",
                table: "Author",
                newName: "IX_Author_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ApplicableFields",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Author",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicableFields_Products_ProductId",
                table: "ApplicableFields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Author_Products_ProductId",
                table: "Author",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
