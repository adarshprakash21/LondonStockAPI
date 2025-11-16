using LondonStockAPI.DataBaseContext;
using LondonStockAPI.Dto;
using LondonStockAPI.Entity;
using LondonStockAPI.Interface;
using LondonStockAPI.Model;
using System.Net;

namespace LondonStockAPI.Service
{
    public class TradeService:ITradeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IPublisherService _publisherService;
        private readonly ILogger<TradeService> _logger;

        public TradeService(IApplicationDbContext dbContext, IPublisherService publisherService, ILogger<TradeService> logger)
        {
            _dbContext = dbContext;
            _publisherService = publisherService;
            _logger = logger;
        }

        public async Task<StatusResponse> PostTrade(TradeDto tradeDto, CancellationToken cancellationToken)
        {
            var trade = new Trades
            {
                Ticker = tradeDto.Ticker,
                Price = tradeDto.Price,
                Shares = tradeDto.Shares,
                BrokerId = tradeDto.BrokerId
            };

            _dbContext.Trades.Add(trade);
            await _dbContext.SaveChangesAsync();

            await _publisherService.PublishToServiceBus(trade, cancellationToken);

            _logger.LogTrace($"Stock traded: {tradeDto.Ticker}");

            return new StatusResponse { StatusCode = HttpStatusCode.OK, Message = "Success" };
        }
    }
}
 