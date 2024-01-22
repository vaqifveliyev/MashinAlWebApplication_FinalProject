using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MashinAl.Data.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DealershipAddress",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DealershipDescription",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DealershipNumber",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                schema: "Membership",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoosted",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDealership",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealershipAddress",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DealershipDescription",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DealershipNumber",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                schema: "Membership",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsBoosted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsDealership",
                table: "Cars");
        }
    }
}
