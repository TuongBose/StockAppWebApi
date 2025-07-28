using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public class WatchListRepository : IWatchListRepository
    {

        private readonly DataBaseContext _dataBaseContext;

        public WatchListRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task AddStockToWatchList(int userId, int stockId)
        {
            var watchList = await _dataBaseContext.WatchLists.FindAsync(userId, stockId);

            if (watchList == null)
            {
                watchList = new WatchList
                {
                    UserId = userId,
                    StockId = stockId
                };

                _dataBaseContext.WatchLists.Add(watchList);
                await _dataBaseContext.SaveChangesAsync(); // COMMIT
            }
        }

        public async Task<WatchList?> GetWatchList(int userId, int stockId)
        {
            return await _dataBaseContext.WatchLists.FirstOrDefaultAsync(watchList =>
                watchList.UserId == userId && watchList.StockId == stockId
            );
        }
    }
}
