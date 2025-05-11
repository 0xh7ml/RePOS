using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePOS.Migrations
{
    /// <inheritdoc />
    public partial class V1_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_category",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_category",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "category",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_category",
                table: "Items",
                column: "category");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_category",
                table: "Items",
                column: "category",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
