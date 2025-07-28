using Microsoft.EntityFrameworkCore;

namespace StockAppWebApi.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<RealtimeQuote> RealtimeQuotes { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Optional: Fluent API configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WatchList>().HasKey(w => new { w.UserId, w.StockId });
            modelBuilder.Entity<Order>().ToTable(table => table.HasTrigger("trigger_orders"));
        }
    }
}
