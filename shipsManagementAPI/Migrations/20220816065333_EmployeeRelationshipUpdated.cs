using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shipsManagementAPI.Migrations
{
    public partial class EmployeeRelationshipUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeGenders_GenderId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Suppliers_SupplierCompanyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SupplierCompanyId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SupplierCompanyId",
                table: "Employees",
                newName: "idSupplierCompany");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Employees",
                newName: "idEmployeeGender");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeGenderId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeGenderId",
                table: "Employees",
                column: "EmployeeGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupplierId",
                table: "Employees",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeGenders_EmployeeGenderId",
                table: "Employees",
                column: "EmployeeGenderId",
                principalTable: "EmployeeGenders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Suppliers_SupplierId",
                table: "Employees",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeGenders_EmployeeGenderId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Suppliers_SupplierId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeGenderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SupplierId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeGenderId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "idSupplierCompany",
                table: "Employees",
                newName: "SupplierCompanyId");

            migrationBuilder.RenameColumn(
                name: "idEmployeeGender",
                table: "Employees",
                newName: "GenderId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupplierCompanyId",
                table: "Employees",
                column: "SupplierCompanyId");

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
        }
    }
}
