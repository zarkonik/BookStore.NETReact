﻿using Microsoft.EntityFrameworkCore;

namespace BookStoreZN.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=bookDb;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Book> Books { get; set; } 
    }
}
