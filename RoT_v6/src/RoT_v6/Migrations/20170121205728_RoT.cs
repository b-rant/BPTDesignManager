using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoT_v6.Migrations
{
    public partial class RoT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Client = table.Column<string>(nullable: true),
                    CompleteDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DesiredDate = table.Column<string>(nullable: true),
                    EstCost = table.Column<float>(nullable: false),
                    EstHours = table.Column<int>(nullable: false),
                    InvCost = table.Column<float>(nullable: false),
                    InvHours = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    jobNum = table.Column<string>(nullable: true)
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
                    CostPer = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstArrDate = table.Column<string>(nullable: true),
                    IdealDelDate = table.Column<string>(nullable: true),
                    JobID = table.Column<string>(nullable: true),
                    PurchDate = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    RequestDate = table.Column<string>(nullable: true),
                    TotalCost = table.Column<string>(nullable: true),
                    Vendor = table.Column<string>(nullable: true)
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
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<string>(nullable: true),
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
                    Description = table.Column<string>(nullable: true),
                    Employee = table.Column<string>(nullable: true),
                    JobID = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    StartTime = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TotalTime = table.Column<double>(nullable: false),
                    partNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.TaskID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
