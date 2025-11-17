using Microsoft.Extensions.Hosting;

namespace LondonStockAPI.Entity
{
    public class Broker
    {
        public int BrokerId { get; set; }
        public string Name { get; set; }
        public ICollection<Trades> Trades { get; set; } = new List<Trades>();
    }
}
