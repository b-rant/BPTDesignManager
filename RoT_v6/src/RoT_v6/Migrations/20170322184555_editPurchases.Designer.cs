using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RoT_v6.Data;

namespace RoT_v6.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170322184555_editPurchases")]
    partial class editPurchases
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RoT_v6.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("RoT_v6.Models.EmployeeTodo", b =>
                {
                    b.Property<string>("employeeId");

                    b.Property<int>("ToDoId");

                    b.HasKey("employeeId", "ToDoId");

                    b.HasIndex("ToDoId");

                    b.HasIndex("employeeId");

                    b.ToTable("EmployeeTodo");
                });

            modelBuilder.Entity("RoT_v6.Models.EmployeeWorkTask", b =>
                {
                    b.Property<string>("employeeId");

                    b.Property<int>("TaskId");

                    b.HasKey("employeeId", "TaskId");

                    b.HasIndex("TaskId");

                    b.HasIndex("employeeId");

                    b.ToTable("EmployeeTask");
                });

            modelBuilder.Entity("RoT_v6.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Client")
                        .IsRequired();

                    b.Property<string>("CompleteDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DesiredDate")
                        .IsRequired();

                    b.Property<decimal>("EstCost");

                    b.Property<int>("EstHours");

                    b.Property<decimal>("InvCost");

                    b.Property<int>("InvHours");

                    b.Property<string>("StartDate");

                    b.Property<int>("Status");

                    b.Property<string>("jobNum")
                        .IsRequired();

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

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("EstArrDate");

                    b.Property<string>("IdealDelDate")
                        .IsRequired();

                    b.Property<int>("JobID");

                    b.Property<string>("Miscellaneous");

                    b.Property<string>("Notes");

                    b.Property<string>("PurchDate");

                    b.Property<int>("Quantity");

                    b.Property<string>("RequestDate");

                    b.Property<string>("ShippingSurcharge");

                    b.Property<decimal>("TotalCost");

                    b.Property<string>("Vendor");

                    b.Property<string>("employeeId");

                    b.HasKey("purchID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("RoT_v6.Models.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("DueDate")
                        .IsRequired();

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

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("JobID");

                    b.Property<string>("Notes");

                    b.Property<string>("StartDate");

                    b.Property<string>("StartTime");

                    b.Property<int>("Status");

                    b.Property<int>("TotalTime");

                    b.Property<string>("employeeId");

                    b.Property<string>("partNum");

                    b.HasKey("TaskID");

                    b.ToTable("WorkTasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RoT_v6.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RoT_v6.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoT_v6.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoT_v6.Models.EmployeeTodo", b =>
                {
                    b.HasOne("RoT_v6.Models.ToDo", "todoItem")
                        .WithMany("EmployeeTodo")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoT_v6.Models.ApplicationUser", "employee")
                        .WithMany("EmployeeTodo")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RoT_v6.Models.EmployeeWorkTask", b =>
                {
                    b.HasOne("RoT_v6.Models.WorkTask", "WorkTaskItem")
                        .WithMany("EmployeeWorkTask")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoT_v6.Models.ApplicationUser", "employee")
                        .WithMany("EmployeeWorkTask")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
