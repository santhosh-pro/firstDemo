using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace firstDemo.Persistence.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "order",
                schema: "order",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    last_modified_at = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    last_modified_by = table.Column<string>(nullable: true),
                    tenant_id = table.Column<string>(nullable: true),
                    description = table.Column<string>(maxLength: 500, nullable: false),
                    order_number = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                    table.UniqueConstraint("ak_order_order_number", x => x.order_number);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                schema: "order",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    last_modified_at = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    last_modified_by = table.Column<string>(nullable: true),
                    tenant_id = table.Column<string>(nullable: true),
                    order_id = table.Column<string>(nullable: false),
                    product_id = table.Column<string>(nullable: false),
                    product_name = table.Column<string>(maxLength: 50, nullable: false),
                    quantity = table.Column<double>(nullable: false),
                    unit_price = table.Column<double>(nullable: false),
                    total_price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_item_order_order_id",
                        column: x => x.order_id,
                        principalSchema: "order",
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_item_product_order_id",
                        column: x => x.order_id,
                        principalSchema: "product",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_item_order_id",
                schema: "order",
                table: "order_item",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_item",
                schema: "order");

            migrationBuilder.DropTable(
                name: "order",
                schema: "order");
        }
    }
}
