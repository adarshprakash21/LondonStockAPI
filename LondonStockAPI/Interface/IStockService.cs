using LondonStockAPI.Dto;

namespace LondonStockAPI.Interface
{
    public interface IStockService
    {
        Task<StockPriceDto> GetStockAsync(string ticker, CancellationToken cancellationToken);
    }
}
