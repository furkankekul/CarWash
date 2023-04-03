using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Customers_CustomerId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CustomerId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "AppointmentsId",
                table: "Employees",
                newName: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RecipeId",
                table: "Customers",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Recipes_RecipeId",
                table: "Customers",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Recipes_RecipeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RecipeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Employees",
                newName: "AppointmentsId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CustomerId",
                table: "Recipes",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Employees_EmployeeId",
                table: "Appointments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Customers_CustomerId",
                table: "Recipes",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
