namespace LondonStockAPI.Entity
{
    public class Trades
    {
        public long TradeId { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public decimal Shares { get; set; }
        public int BrokerId { get; set; }
        public DateTime TradedOn { get; set; } = DateTime.UtcNow;
    }
}
