using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace firstDemo.Persistence.Migrations
{
    public partial class orderTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_track",
                schema: "order",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    last_modified_at = table.Column<DateTime>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    last_modified_by = table.Column<string>(nullable: true),
                    order_id = table.Column<string>(nullable: false),
                    tracking_date = table.Column<DateTime>(nullable: false),
                    order_status_id = table.Column<int>(nullable: false),
                    order_status_name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_track", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_track_order_order_id",
                        column: x => x.order_id,
                        principalSchema: "order",
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_track_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalSchema: "order",
                        principalTable: "order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_track_order_id",
                schema: "order",
                table: "order_track",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_track_order_status_id",
                schema: "order",
                table: "order_track",
                column: "order_status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_track",
                schema: "order");
        }
    }
}
