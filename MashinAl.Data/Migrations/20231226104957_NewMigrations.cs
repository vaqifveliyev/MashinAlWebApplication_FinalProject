using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MashinAl.Data.Migrations
{
    public partial class NewMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSupplies_CarStatus_CarId",
                table: "CarSupplies");

            migrationBuilder.DropForeignKey(
                name: "FK_CarSupplies_Supply_SupplyId",
                table: "CarSupplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supply",
                table: "Supply");

            migrationBuilder.RenameTable(
                name: "Supply",
                newName: "Supplies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Supplies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplies",
                table: "Supplies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSupplies_Supplies_SupplyId",
                table: "CarSupplies",
                column: "SupplyId",
                principalTable: "Supplies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSupplies_Supplies_SupplyId",
                table: "CarSupplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplies",
                table: "Supplies");

            migrationBuilder.RenameTable(
                name: "Supplies",
                newName: "Supply");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Supply",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supply",
                table: "Supply",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSupplies_CarStatus_CarId",
                table: "CarSupplies",
                column: "CarId",
                principalTable: "CarStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSupplies_Supply_SupplyId",
                table: "CarSupplies",
                column: "SupplyId",
                principalTable: "Supply",
                principalColumn: "Id");
        }
    }
}
