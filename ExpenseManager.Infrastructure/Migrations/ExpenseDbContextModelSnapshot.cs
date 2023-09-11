﻿// <auto-generated />
using System;
using ExpenseManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseManager.Infrastructure.Migrations
{
    [DbContext(typeof(ExpenseDbContext))]
    partial class ExpenseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpenseManager.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.Entities.SavingGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SavingGoals", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfDisplayedActions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Settings", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.Entities.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Left")
                        .HasColumnType("real");

                    b.Property<int>("SavingGoalId")
                        .HasColumnType("int");

                    b.Property<float>("Spent")
                        .HasColumnType("real");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SavingGoalId");

                    b.ToTable("Stats", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.Entities.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ingoing")
                        .HasColumnType("bit");

                    b.Property<bool>("Upcoming")
                        .HasColumnType("bit");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transfers", (string)null);
                });

            modelBuilder.Entity("ExpenseManager.Domain.Entities.Stat", b =>
                {
                    b.HasOne("ExpenseManager.Domain.Entities.SavingGoal", "SavingGoal")
                        .WithMany()
                        .HasForeignKey("SavingGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SavingGoal");
                });

            modelBuilder.Entity("ExpenseManager.Domain.Entities.Transfer", b =>
                {
                    b.HasOne("ExpenseManager.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
