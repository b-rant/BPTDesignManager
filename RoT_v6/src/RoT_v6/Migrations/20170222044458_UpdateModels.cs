using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoT_v6.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "jobNum",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "InvCost",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "EstHours",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "DesiredDate",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Client",
                table: "Jobs",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "jobNum",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "InvCost",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "EstHours",
                table: "Jobs",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "DesiredDate",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Client",
                table: "Jobs",
                nullable: true);
        }
    }
}
