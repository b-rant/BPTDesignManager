using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using RoT_v6.Models;

namespace RoT_v6.Migrations
{
    public partial class editTODOs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ToDos",
                nullable: false,
                defaultValue: ToDoStatus.Active);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ToDos");
        }
    }
}
