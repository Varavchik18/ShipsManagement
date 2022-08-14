using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shipsManagementAPI.Migrations
{
    public partial class AddedRelationShipsBetweenEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmountOfAvailableShips",
                table: "Suppliers",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "CountryId");

            migrationBuilder.CreateTable(
                name: "SupplierCustomers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierCustomers", x => new { x.SupplierId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_SupplierCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierCustomers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierCustomers_CustomerId",
                table: "SupplierCustomers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Countries_CountryId",
                table: "Suppliers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Countries_CountryId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Suppliers",
                newName: "AmountOfAvailableShips");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "Id");
        }
    }
}
