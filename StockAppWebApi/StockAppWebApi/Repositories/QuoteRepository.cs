using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public QuoteRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
        {
            //var fromDate = DateTime.Now.Date.AddDays(-days);
            //var toDate = DateTime.Now.Date;

            var fromDate = new DateTime(2023, 4, 15);
            var toDate = new DateTime(2023, 5, 15);

            var historicalQuotes = await _dataBaseContext.Quotes
                .Where(q =>
                q.TimeStamp >= fromDate &&
                q.TimeStamp <= toDate &&
                q.StockId == stockId
                ) // Kiểm tra stock_id
                .GroupBy(q => q.TimeStamp.Date) // Nhóm theo ngày
                                                // mapping
                .Select(g => new Quote
                {
                    TimeStamp = g.Key,
                    Price = g.Average(q => q.Price), // Lấy giá trị trung bình của cùng 1 ngày
                    // Dung de ve do thi gia theo ngay
                })
                .OrderBy(q => q.TimeStamp) // Sắp xếp theo thứ tự tăng dần về ngày tháng
                .ToListAsync();
            return historicalQuotes;
        }

        public async Task<List<RealtimeQuote>?> GetRealtimeQuotes(
            int page,
            int limit,
            string sector,
            string industry
            )
        {
            var query = _dataBaseContext.RealtimeQuotes
                .Skip((page - 1) * limit) // Bỏ qua số lượng bản ghi trước trang hiện tại
                .Take(limit); // Lấy số lượng bản ghi tối đa trên mỗi trang

            if (!string.IsNullOrEmpty(sector))
            {
                query = query.Where(x => x.Sector == sector);
            }
            if (!string.IsNullOrEmpty(industry))
            {
                query = query.Where(x => x.Industry == industry);
            }

            var quotes = await query.ToListAsync();
            return quotes;
        }
    }
}
