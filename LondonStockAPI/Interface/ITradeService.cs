using LondonStockAPI.Dto;
using LondonStockAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockAPI.Interface
{
    public interface ITradeService
    {
        Task<StatusResponse> PostTrade(TradeDto tradeDto, CancellationToken cancellationToken);
    }
}
