using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoT_v6.Migrations
{
    public partial class editPurchasesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ShippingSurcharge",
                table: "Purchase",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Miscellaneous",
                table: "Purchase",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "CostPer",
                table: "Purchase",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShippingSurcharge",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Miscellaneous",
                table: "Purchase",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CostPer",
                table: "Purchase",
                nullable: true);
        }
    }
}
