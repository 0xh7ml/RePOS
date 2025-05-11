using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RePOS.Migrations
{
    /// <inheritdoc />
    public partial class V1_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_item",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_order",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_payment_method",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.RenameColumn(
                name: "payment_method",
                table: "Orders",
                newName: "payment_method_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_payment_method",
                table: "Orders",
                newName: "IX_Orders_payment_method_id");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "OrderItems",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "item",
                table: "OrderItems",
                newName: "item_id");

            migrationBuilder.RenameColumn(
                name: "qty",
                table: "OrderItems",
                newName: "quantity");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_order",
                table: "OrderItems",
                newName: "IX_OrderItems_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_item",
                table: "OrderItems",
                newName: "IX_OrderItems_item_id");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_item_id",
                table: "OrderItems",
                column: "item_id",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_order_id",
                table: "OrderItems",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_payment_method_id",
                table: "Orders",
                column: "payment_method_id",
                principalTable: "PaymentMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_item_id",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_order_id",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_payment_method_id",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "payment_method_id",
                table: "Orders",
                newName: "payment_method");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_payment_method_id",
                table: "Orders",
                newName: "IX_Orders_payment_method");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderItems",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "OrderItems",
                newName: "item");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderItems",
                newName: "qty");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_order_id",
                table: "OrderItems",
                newName: "IX_OrderItems_order");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_item_id",
                table: "OrderItems",
                newName: "IX_OrderItems_item");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "Orders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<float>(
                name: "total",
                table: "Orders",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_item",
                table: "OrderItems",
                column: "item",
                principalTable: "Items",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_order",
                table: "OrderItems",
                column: "order",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_payment_method",
                table: "Orders",
                column: "payment_method",
                principalTable: "PaymentMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
