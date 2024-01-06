using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MashinAl.Data.Migrations
{
    public partial class PlateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Plates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Plates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Plates");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Plates");
        }
    }
}
