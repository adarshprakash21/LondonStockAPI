using Azure.Messaging;
using Azure.Messaging.ServiceBus;
using LondonStockAPI.Entity;
using LondonStockAPI.Interface;
using LondonStockAPI.Model;
using Microsoft.Extensions.Logging;

namespace LondonStockAPI.Service
{
    public class PublisherService: IPublisherService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PublisherService> _logger;
        public PublisherService(IConfiguration configuration, ILogger<PublisherService> logger) 
        { 
            _configuration = configuration;
            _logger = logger;
        }
        public async Task PublishToServiceBus(Trades trade, CancellationToken cancellationToken)
        {
            string connectionString = _configuration["AzureServiceBus:ConnectionString"];
            await using var client = new ServiceBusClient(connectionString);
            ServiceBusSender sender = client.CreateSender(trade.Ticker);

            try
            {
                var postmessage = $"{trade.Shares} number of {trade.Ticker} traded for {trade.Price} on {trade.TradedOn}";
                ServiceBusMessage message = new ServiceBusMessage(postmessage);
                await sender.SendMessageAsync(message, cancellationToken);
                _logger.LogTrace(postmessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
                _logger.LogError($"Error sending message: {ex.Message}");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
