using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public class CWRepository : ICWRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public CWRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId)
        {
            return await _dataBaseContext.CoveredWarrants
                .Where(cw => cw.UnderlyingAssetId == stockId)
                .Include(cw => cw.Stock)
                .ToListAsync();
        }
    }
}
