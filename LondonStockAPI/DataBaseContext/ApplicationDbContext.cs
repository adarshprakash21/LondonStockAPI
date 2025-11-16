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
            modelBuilder.Entity<Stocks>().HasKey(s => s.Ticker);
            modelBuilder.Entity<Broker>().HasKey(b => b.BrokerId);
            modelBuilder.Entity<Trades>().HasKey(t => t.TradeId);
            modelBuilder.Entity<User>().HasKey(t => t.Id);
            modelBuilder.Entity<Trades>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Trades>()
                .Property(p => p.Shares)
                .HasColumnType("decimal(18,2)");
        }
    }
}
