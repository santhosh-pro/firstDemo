using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace firstDemo.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "audit");

            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "audit_log",
                schema: "audit",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    table_name = table.Column<string>(nullable: true),
                    date_time = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    key_values = table.Column<string>(nullable: true),
                    old_values = table.Column<string>(nullable: true),
                    new_values = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
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
                    description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_log",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "category",
                schema: "product");
        }
    }
}
