using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoT_v6.Migrations
{
    public partial class purch_emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeId",
                table: "Purchase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "Purchase");
        }
    }
}
