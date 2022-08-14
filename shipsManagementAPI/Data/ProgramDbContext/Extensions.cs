using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shipsManagementAPI.Data.Models;

namespace shipsManagementAPI.Data.ProgramDbContext
{
    public static class Extensions
    {
        public static void ConfigureRelationships(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Suppliers)
                .WithOne(c => c.Country)
                .IsRequired();

            modelBuilder.Entity<EmployeeGender>()
                .HasMany(c => c.Employees)
                .WithOne(c => c.Gender);

            modelBuilder.Entity<Employee>()
                .HasOne(c => c.SupplierCompany)
                .WithMany(c => c.Employees)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasKey(bc => new { bc.SupplierId, bc.CustomerId });

            modelBuilder.Entity<Order>()
                .HasOne(bc => bc.Supplier)
                .WithMany(b => b.SupplierCustomers)
                .HasForeignKey(bc => bc.SupplierId);

            modelBuilder.Entity<Order>()
                .HasOne(c => c.OrderStatus)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.OrderStatusId);

            modelBuilder.Entity<Order>()
                .HasOne(bc => bc.Customer)
                .WithMany(c => c.SupplierCustomers)
                .HasForeignKey(bc => bc.CustomerId);
        }
    }
}