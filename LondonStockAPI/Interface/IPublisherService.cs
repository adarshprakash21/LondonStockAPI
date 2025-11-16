using LondonStockAPI.Entity;

namespace LondonStockAPI.Interface
{
    public interface IPublisherService
    {
        Task PublishToServiceBus(Trades trade, CancellationToken cancellationToken);
    }
}
