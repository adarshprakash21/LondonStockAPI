using LondonStockAPI.Interface;
using LondonStockAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("trades")]
    public class TradesController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        public TradesController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }
        /// <summary>
        /// Method post Trades to TradeService
        /// </summary>
        /// <param tradteDto=>Taraded Stock defention</param>
        /// <returns>Status Response</returns>
        [HttpPost]
        public async Task<IActionResult> PostTrade([FromBody] TradeDto tradteDto, CancellationToken cancellationToken)
        {
            if (tradteDto != null)
            {
                var response = await _tradeService.PostTrade(tradteDto, cancellationToken);
                return Ok(response);
            }
            else
                return BadRequest(tradteDto);
        }
    }
}
