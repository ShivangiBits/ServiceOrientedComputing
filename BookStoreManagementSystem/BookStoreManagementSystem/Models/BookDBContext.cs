using BookStoreManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookManagement.Models
{
    public class BookDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookManagment");
        }

        public DbSet<Book> Books { get; set; }
        
    }
}
