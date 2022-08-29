﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shipsManagementAPI.Data.ProgramDbContext;

#nullable disable

namespace shipsManagementAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220817090829_EditedKeyOrder")]
    partial class EditedKeyOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmountOfOrders")
                        .HasColumnType("int");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CustomerPhone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeGenderId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("idEmployeeGender")
                        .HasColumnType("int");

                    b.Property<int>("idSupplierCompany")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeGenderId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.EmployeeGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeGenders");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Order", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferValueAmount")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<string>("OrderTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OrderStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmountOfCustomers")
                        .HasColumnType("int");

                    b.Property<int>("AmountOfShips")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("SupplierAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SupplierPhone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Employee", b =>
                {
                    b.HasOne("shipsManagementAPI.Data.Models.EmployeeGender", null)
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeGenderId");

                    b.HasOne("shipsManagementAPI.Data.Models.Supplier", null)
                        .WithMany("Employees")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Order", b =>
                {
                    b.HasOne("shipsManagementAPI.Data.Models.Customer", null)
                        .WithMany("CustomersOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shipsManagementAPI.Data.Models.OrderStatus", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shipsManagementAPI.Data.Models.Supplier", null)
                        .WithMany("SupplierOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Supplier", b =>
                {
                    b.HasOne("shipsManagementAPI.Data.Models.Country", null)
                        .WithMany("Suppliers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Country", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Customer", b =>
                {
                    b.Navigation("CustomersOrders");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.EmployeeGender", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("shipsManagementAPI.Data.Models.Supplier", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("SupplierOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
