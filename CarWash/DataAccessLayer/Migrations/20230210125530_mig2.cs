using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Employees_EmployeesEmployeeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "EmployeesEmployeeId",
                table: "Customers",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_EmployeesEmployeeId",
                table: "Customers",
                newName: "IX_Customers_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Employees_EmployeeId",
                table: "Customers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Employees_EmployeeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Customers",
                newName: "EmployeesEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_EmployeeId",
                table: "Customers",
                newName: "IX_Customers_EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Employees_EmployeesEmployeeId",
                table: "Customers",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
