using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public class UserDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UserManagment");
        }

        public DbSet<User> users { get; set; }

    }
}
