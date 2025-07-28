using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public OrderRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<Order> CreateOrder(OrderViewModel orderViewModel)
        {
            // create order from orderviewmodel
            Order order = new Order
            {
                UserId = orderViewModel.UserId,
                StockId = orderViewModel.StockId,
                OrderType = orderViewModel.OrderType,
                Direction = orderViewModel.Direction,
                Quantity = orderViewModel.Quantity,
                Price = orderViewModel.Price,
                Status = orderViewModel.Status,
                OrderDate = DateTime.Now,
            };
            _dataBaseContext.Orders.Add(order);
            await _dataBaseContext.SaveChangesAsync();
            return order;
        }
    }
}
