using LondonStockAPI.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("stocks")]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        /// <summary>
        /// Method get Stock average prices
        /// </summary>
        /// <param ticker=>stock ticker</param>
        /// <returns>ticker, avgPrice</returns>
        [HttpGet("{ticker}/value")]
        public async Task<IActionResult> GetStockAsync(string ticker, CancellationToken cancellationToken)
        {
            var value = await _stockService.GetStockAsync(ticker, cancellationToken);

            if (value == null)
                return NotFound("Ticker not found");

            return Ok(new { ticker, avgPrice = value.AveragePrice });
        }
    }
}
