using LondonStockAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace LondonStockAPI.DataBaseContext
{
    public interface IApplicationDbContext
    {
        DbSet<User> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Stocks> Stocks { get; set; }
        DbSet<Broker> Broker { get; set; }
        DbSet<Trades> Trades { get; set; }
    }
}
