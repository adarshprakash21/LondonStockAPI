namespace LondonStockAPI.Model
{
    public class TradeDto
    {
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public decimal Shares { get; set; }
        public int BrokerId { get; set; }
    }
}
