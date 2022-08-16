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
            modelBuilder.Entity<Order>()
                .HasKey(bc => new { bc.SupplierId, bc.CustomerId });
        }
    }
}