using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace StockAppWebApi.Controllers
{
    [ApiController]
    [Route("api/ws")]
    public class WebSocketController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                // Sinh ngau nhien 2 gia tri x, y, thay doi 2 giay/lan
                var random = new Random();
                while (webSocket.State == WebSocketState.Open)
                {
                    // Tao gia tri x, y ngau nhien
                    int x = random.Next(1, 100);
                    int y = random.Next(1, 100);
                    var buffer = Encoding.UTF8.GetBytes($"{{ \"x\":{x}, \"y\":{y}}}");
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
    }
}
