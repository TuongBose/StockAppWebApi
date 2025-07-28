using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IWatchListRepository _watchListRepository;

        public WatchListService(IWatchListRepository watchListRepository)
        {
            _watchListRepository = watchListRepository;
        }

        public async Task AddStockToWatchList(int userId, int stockId)
        {
            WatchList? existingWatchList = await _watchListRepository.GetWatchList(userId, stockId);
            if (existingWatchList != null)
            {
                throw new Exception("Stock is already in WatchList");
            }

            await _watchListRepository.AddStockToWatchList(userId, stockId);
        }

        public Task<WatchList> GetWatchList(int userId, int stockId)
        {
            throw new NotImplementedException();
        }
    }
}
