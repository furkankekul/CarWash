﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(CarWashesDbContext))]
    [Migration("20230213065920_Appointment_ForeignKey")]
    partial class AppointmentForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityLayer.Concrete.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentEndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("AppointmentEntryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("EmployeeId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<bool>("Subscriber")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeDiscountId")
                        .HasColumnType("int");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RecipePrice")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("EntityLayer.Concrete.RecipeDiscount", b =>
                {
                    b.Property<int>("RecipeDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("double");

                    b.HasKey("RecipeDiscountId");

                    b.ToTable("RecipeDiscounts");
                });

            modelBuilder.Entity("RecipeRecipeDiscount", b =>
                {
                    b.Property<int>("RecipeDiscountsRecipeDiscountId")
                        .HasColumnType("int");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("int");

                    b.HasKey("RecipeDiscountsRecipeDiscountId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("RecipeRecipeDiscount");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Appointment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Customer", "Customer")
                        .WithOne("Appointment")
                        .HasForeignKey("EntityLayer.Concrete.Appointment", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Employee", "Employee")
                        .WithMany("Appointments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Customer", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Employee", "Employee")
                        .WithMany("Customers")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("EntityLayer.Concrete.Recipe", "Recipe")
                        .WithMany("Customers")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Employee");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeRecipeDiscount", b =>
                {
                    b.HasOne("EntityLayer.Concrete.RecipeDiscount", null)
                        .WithMany()
                        .HasForeignKey("RecipeDiscountsRecipeDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.Customer", b =>
                {
                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Employee", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Recipe", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
