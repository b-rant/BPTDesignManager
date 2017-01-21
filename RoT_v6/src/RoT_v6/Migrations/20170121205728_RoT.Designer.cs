using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RoT_v6.Data;

namespace RoT_v6.Migrations
{
    [DbContext(typeof(RoTContext))]
    [Migration("20170121205728_RoT")]
    partial class RoT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RoT_v6.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Client");

                    b.Property<string>("CompleteDate");

                    b.Property<string>("Description");

                    b.Property<string>("DesiredDate");

                    b.Property<float>("EstCost");

                    b.Property<int>("EstHours");

                    b.Property<float>("InvCost");

                    b.Property<int>("InvHours");

                    b.Property<string>("StartDate");

                    b.Property<int>("Status");

                    b.Property<string>("jobNum");

                    b.HasKey("JobID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("RoT_v6.Models.Purchase", b =>
                {
                    b.Property<int>("purchID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArrivedDate");

                    b.Property<bool>("Block");

                    b.Property<string>("CostPer");

                    b.Property<string>("Description");

                    b.Property<string>("EstArrDate");

                    b.Property<string>("IdealDelDate");

                    b.Property<string>("JobID");

                    b.Property<string>("PurchDate");

                    b.Property<int>("Quantity");

                    b.Property<string>("RequestDate");

                    b.Property<string>("TotalCost");

                    b.Property<string>("Vendor");

                    b.HasKey("purchID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("RoT_v6.Models.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("DueDate");

                    b.Property<int>("Priority");

                    b.HasKey("ToDoId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("RoT_v6.Models.WorkTask", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Block");

                    b.Property<string>("CompleteDate");

                    b.Property<string>("Description");

                    b.Property<string>("Employee");

                    b.Property<int>("JobID");

                    b.Property<string>("Notes");

                    b.Property<string>("StartDate");

                    b.Property<double>("StartTime");

                    b.Property<int>("Status");

                    b.Property<double>("TotalTime");

                    b.Property<string>("partNum");

                    b.HasKey("TaskID");

                    b.ToTable("WorkTasks");
                });
        }
    }
}
