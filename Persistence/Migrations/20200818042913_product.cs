using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace firstDemo.Persistence.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                schema: "product",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    last_modified_at = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    last_modified_by = table.Column<string>(nullable: true),
                    tenant_id = table.Column<string>(nullable: true),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    category_id = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "product",
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_product_category_id",
                schema: "product",
                table: "product",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product",
                schema: "product");
        }
    }
}
