using LondonStockAPI.DataBaseContext;
using LondonStockAPI.Dto;
using LondonStockAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LondonStockAPI.Service
{
    public class StockService: IStockService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<StockService> _logger;
        public StockService(IApplicationDbContext dbContext, ILogger<StockService> logger) 
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<StockPriceDto> GetStockAsync(string ticker, CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Trades.Where(x => x.Ticker == ticker).GroupBy(x => x.Ticker)
                .Select(s => new StockPriceDto()
                {
                    Ticker = s.Key,
                    AveragePrice = s.Average(p => p.Price)
                }).FirstOrDefaultAsync(cancellationToken);

            if (stock != null)
            {
                _logger.LogTrace($"Stock found: {stock.Ticker}");
                return stock;
            }
                
            else
            {
                _logger.LogTrace($"Stock not found: {stock.Ticker}");
                return null;
            }
                
        }
    }
}
