﻿using Microsoft.EntityFrameworkCore;

namespace StockAppWebApi.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }

        // Optional: Fluent API configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
