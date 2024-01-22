﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MashinAl.Data.Migrations
{
    public partial class BalanceUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Balance",
                schema: "Membership",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                schema: "Membership",
                table: "Users");
        }
    }
}
