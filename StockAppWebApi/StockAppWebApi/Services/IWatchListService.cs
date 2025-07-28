using StockAppWebApi.Models;

namespace StockAppWebApi.Services
{
    public interface IWatchListService
    {
        Task AddStockToWatchList(int userId, int stockId);
        Task<WatchList> GetWatchList(int userId, int stockId);
    }
}
