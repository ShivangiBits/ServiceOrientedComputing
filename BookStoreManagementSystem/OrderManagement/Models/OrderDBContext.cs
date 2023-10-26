using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public class OrderDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrderManagment");
        }

        public DbSet<Order> Orders { get; set; }

    }
}
