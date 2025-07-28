using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(OrderViewModel orderViewModel);
        Task<List<Order>> GetOrderHistory();
    }
}
