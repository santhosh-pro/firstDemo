using Microsoft.EntityFrameworkCore.Migrations;

namespace firstDemo.Persistence.Migrations
{
    public partial class orderTrack2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order_status_name",
                schema: "order",
                table: "order_track");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "order_status_name",
                schema: "order",
                table: "order_track",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
