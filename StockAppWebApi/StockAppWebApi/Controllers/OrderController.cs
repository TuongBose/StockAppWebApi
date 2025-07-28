using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Attributes;
using StockAppWebApi.Extensions;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpPost("place-order")]
        [JwtAuthorize]
        public async Task<IActionResult> PlaceOrder(OrderViewModel orderViewModel)
        {
            // Lay UserId tu jwtAuthorize 
            int userId = HttpContext.GetUserId();
            // Kiem tra xem nguoi dung co ton tai
            var existingUser = await _userService.GetUserById(userId);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }
            orderViewModel.UserId = userId;
            var createOrder = await _orderService.PlaceOrder(orderViewModel);
            return Ok(createOrder);
        }

    }
}
