using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shipsManagementAPI.Migrations
{
    public partial class Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfCustomers",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfCustomers",
                table: "Suppliers");
        }
    }
}
