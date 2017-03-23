using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoT_v6.Migrations
{
    public partial class editPurchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Miscellaneous",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingSurcharge",
                table: "Purchase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Miscellaneous",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "ShippingSurcharge",
                table: "Purchase");
        }
    }
}
