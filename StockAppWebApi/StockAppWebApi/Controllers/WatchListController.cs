using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Attributes;
using StockAppWebApi.Extensions;
using StockAppWebApi.Services;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListService _watchListService;
        private readonly IUserService _userService;
        private readonly IStockService _stockService;

        public WatchListController(
            IWatchListService watchListService,
            IUserService userService,
            IStockService stockService)
        {
            _watchListService = watchListService;
            _userService = userService;
            _stockService = stockService;
        }

        [HttpPost("addstocktowatchlist/{stockId}")]
        [JwtAuthorize]
        public async Task<IActionResult> AddStockToWatchList(int stockId)
        {
            try
            {
                // Lay UserId tu authorizationFilterContext
                int userId = HttpContext.GetUserId();

                // Kiem tra nguoi dung va co phieu ton tai
                var user = await _userService.GetUserById(userId);
                var stock = await _stockService.GetStockById(stockId);

                if (user == null)
                {
                    return NotFound("User not found.");
                }
                if (stock == null)
                {
                    return NotFound("Stock not found");
                }

                await _watchListService.AddStockToWatchList(userId, stockId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
