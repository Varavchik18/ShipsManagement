using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shipsManagementAPI.Migrations
{
    public partial class ImprovedOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeGender_GenderId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Suppliers_SupplierCompanyId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierCustomers_Customers_CustomerId",
                table: "SupplierCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierCustomers_Suppliers_SupplierId",
                table: "SupplierCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierCustomers",
                table: "SupplierCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeGender",
                table: "EmployeeGender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "SupplierCustomers",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "EmployeeGender",
                newName: "EmployeeGenders");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierCustomers_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_SupplierCompanyId",
                table: "Employees",
                newName: "IX_Employees_SupplierCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_GenderId",
                table: "Employees",
                newName: "IX_Employees_GenderId");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                columns: new[] { "SupplierId", "CustomerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeGenders",
                table: "EmployeeGenders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeGenders_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "EmployeeGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Suppliers_SupplierCompanyId",
                table: "Employees",
                column: "SupplierCompanyId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Suppliers_SupplierId",
                table: "Orders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeGenders_GenderId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Suppliers_SupplierCompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Suppliers_SupplierId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeGenders",
                table: "EmployeeGenders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "SupplierCustomers");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeGenders",
                newName: "EmployeeGender");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "SupplierCustomers",
                newName: "IX_SupplierCustomers_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SupplierCompanyId",
                table: "Employee",
                newName: "IX_Employee_SupplierCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_GenderId",
                table: "Employee",
                newName: "IX_Employee_GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierCustomers",
                table: "SupplierCustomers",
                columns: new[] { "SupplierId", "CustomerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeGender",
                table: "EmployeeGender",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeGender_GenderId",
                table: "Employee",
                column: "GenderId",
                principalTable: "EmployeeGender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Suppliers_SupplierCompanyId",
                table: "Employee",
                column: "SupplierCompanyId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierCustomers_Customers_CustomerId",
                table: "SupplierCustomers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierCustomers_Suppliers_SupplierId",
                table: "SupplierCustomers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
