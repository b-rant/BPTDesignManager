using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoT_v6.Data.Migrations
{
    public partial class work : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Client = table.Column<string>(nullable: false),
                    CompleteDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    DesiredDate = table.Column<string>(nullable: false),
                    EstCost = table.Column<decimal>(nullable: false),
                    EstHours = table.Column<int>(nullable: false),
                    InvCost = table.Column<decimal>(nullable: false),
                    InvHours = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    jobNum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    purchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrivedDate = table.Column<string>(nullable: true),
                    Block = table.Column<bool>(nullable: false),
                    CostPer = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EstArrDate = table.Column<string>(nullable: false),
                    IdealDelDate = table.Column<string>(nullable: false),
                    JobID = table.Column<int>(nullable: false),
                    PurchDate = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RequestDate = table.Column<string>(nullable: false),
                    TotalCost = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.purchID);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Block = table.Column<bool>(nullable: false),
                    CompleteDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    JobID = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    StartTime = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TotalTime = table.Column<int>(nullable: false),
                    partNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.TaskID);
                });

            migrationBuilder.AddColumn<int>(
                name: "WorkTaskTaskID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkTaskTaskID",
                table: "AspNetUsers",
                column: "WorkTaskTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkTasks_WorkTaskTaskID",
                table: "AspNetUsers",
                column: "WorkTaskTaskID",
                principalTable: "WorkTasks",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkTasks_WorkTaskTaskID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkTaskTaskID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkTaskTaskID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "WorkTasks");
        }
    }
}
