using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace firstDemo.Persistence.Migrations
{
    public partial class orderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "product",
                table: "product");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "product",
                table: "category");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "order",
                table: "order_item");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "order",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "order_status_id",
                schema: "order",
                table: "order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "order_status",
                schema: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_status", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "order",
                table: "order_status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Packing" },
                    { 3, "Shipping" },
                    { 4, "Delivered" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_order_status_id",
                schema: "order",
                table: "order",
                column: "order_status_id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_order_status_order_status_id",
                schema: "order",
                table: "order",
                column: "order_status_id",
                principalSchema: "order",
                principalTable: "order_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_order_status_order_status_id",
                schema: "order",
                table: "order");

            migrationBuilder.DropTable(
                name: "order_status",
                schema: "order");

            migrationBuilder.DropIndex(
                name: "ix_order_order_status_id",
                schema: "order",
                table: "order");

            migrationBuilder.DropColumn(
                name: "order_status_id",
                schema: "order",
                table: "order");

            migrationBuilder.AddColumn<string>(
                name: "tenant_id",
                schema: "product",
                table: "product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tenant_id",
                schema: "product",
                table: "category",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tenant_id",
                schema: "order",
                table: "order_item",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tenant_id",
                schema: "order",
                table: "order",
                type: "text",
                nullable: true);
        }
    }
}
