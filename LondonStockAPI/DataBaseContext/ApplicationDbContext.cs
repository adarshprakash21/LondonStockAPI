using LondonStockAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.DataBaseContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Broker> Broker { get; set; }
        public DbSet<Trades> Trades { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stocks>(s =>
            {
                s.HasKey(s => s.Ticker);
                s.Property(s => s.Ticker)
                      .IsRequired();
                s.HasMany(s => s.Trades)
                      .WithOne(t => t.Stocks)
                      .HasForeignKey(t => t.Ticker)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Broker>(p =>
            {
                p.HasKey(b => b.BrokerId);
                p.Property(b => b.BrokerId)
                  .IsRequired();
                p.HasMany(b => b.Trades)
                  .WithOne(t => t.Broker)
                  .HasForeignKey(t => t.BrokerId)
                  .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Trades>(t =>
            {
                t.HasKey(b => b.TradeId);
            });

            modelBuilder.Entity<User>().HasKey(t => t.Id);

            modelBuilder.Entity<Trades>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Trades>()
                .Property(p => p.Shares)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Stocks>().HasData(
                new Stocks { Ticker = "AAPL", Name = "Apple Inc." },
                new Stocks { Ticker = "MSFT", Name = "Microsoft Corp." },
                new Stocks { Ticker = "GOOGL", Name = "Alphabet Inc" },
                new Stocks { Ticker = "F", Name = "Ford Motor Company" },
                new Stocks { Ticker = "TSLA", Name = "Tesla, Inc." },
                new Stocks { Ticker = "WMT", Name = "Walmart" }
            );

            modelBuilder.Entity<Broker>().HasData(
                new Broker { BrokerId = 1, Name = "Zerodha" },
                new Broker { BrokerId = 2, Name = "Upstox" }
            );
        }
    }
}
