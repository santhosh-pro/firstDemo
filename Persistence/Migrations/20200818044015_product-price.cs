using Microsoft.EntityFrameworkCore.Migrations;

namespace firstDemo.Persistence.Migrations
{
    public partial class productprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price",
                schema: "product",
                table: "product",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                schema: "product",
                table: "product");
        }
    }
}
