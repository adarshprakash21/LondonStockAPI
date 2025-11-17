namespace LondonStockAPI.Entity
{
    public class Stocks
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public ICollection<Trades> Trades { get; set; } = new List<Trades>();
    }
}
