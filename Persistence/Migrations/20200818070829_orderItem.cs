using Microsoft.EntityFrameworkCore.Migrations;

namespace firstDemo.Persistence.Migrations
{
    public partial class orderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_item_product_order_id",
                schema: "order",
                table: "order_item");

            migrationBuilder.CreateIndex(
                name: "ix_order_item_product_id",
                schema: "order",
                table: "order_item",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_item_product_product_id",
                schema: "order",
                table: "order_item",
                column: "product_id",
                principalSchema: "product",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_item_product_product_id",
                schema: "order",
                table: "order_item");

            migrationBuilder.DropIndex(
                name: "ix_order_item_product_id",
                schema: "order",
                table: "order_item");

            migrationBuilder.AddForeignKey(
                name: "fk_order_item_product_order_id",
                schema: "order",
                table: "order_item",
                column: "order_id",
                principalSchema: "product",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
