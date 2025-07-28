using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Stock?> GetStockById(int stockId)
        {
            Stock? stock = await _stockRepository.GetStockById(stockId);
            return stock;
        }
    }

}
