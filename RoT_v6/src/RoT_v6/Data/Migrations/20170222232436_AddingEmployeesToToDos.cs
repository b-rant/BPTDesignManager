using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoT_v6.Data.Migrations
{
    public partial class AddingEmployeesToToDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToDoId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ToDoId",
                table: "AspNetUsers",
                column: "ToDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ToDos_ToDoId",
                table: "AspNetUsers",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "ToDoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ToDos_ToDoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ToDoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ToDoId",
                table: "AspNetUsers");
        }
    }
}
