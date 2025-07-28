using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("ws")] //https://localhost:7199/api/quote/ws
        public async Task GetRealtimeQuotes(
            int page = 1,
            int limit = 10,
            string sector = "",
            string industry = ""
            )
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                while (webSocket.State == WebSocketState.Open)
                {
                    // Lay du lieu duoi service, service goi repository
                    List<RealtimeQuote>? realtimeQuotes = await _quoteService.GetRealtimeQuotes(page, limit, sector, industry);

                    // Convert list of object to json
                    string jsonString = JsonSerializer.Serialize(realtimeQuotes);
                    var buffer = Encoding.UTF8.GetBytes(jsonString);
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None
                    );
                    await Task.Delay(2000); // Doi 2 giay truoc khi gui tiep gia tri tiep theo
                }
                await webSocket.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    "Connection closed by the server",
                    CancellationToken.None
                );
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalQuotes(int days, int stockId)
        {
            var historicalQuotes = await _quoteService.GetHistoricalQuotes(days, stockId);
            return Ok(historicalQuotes);
        }
    }
}
