using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public StockRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<Stock?> GetStockById(int stockid)
        {
            return await _dataBaseContext.Stocks.FindAsync(stockid);
        }
    }
}
