using System.Net;

namespace LondonStockAPI.Dto
{
    public class StatusResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
