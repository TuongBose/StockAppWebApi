using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("stocks")]
    public class Stock
    {
        [Key]
        [Column("stock_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Symbol is required")]
        [Column("symbol")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Symbol must be between 1 and 10 characters")]
        public string? Symbol { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [Column("company_name")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Company name must be between 2 and 255 characters")]
        public string? CompanyName { get; set; }

        [Column("market_cap")]
        [Range(0, double.MaxValue, ErrorMessage = "Market cap must be non-negative")]
        public decimal? MarketCap { get; set; }

        [Column("sector")]
        [StringLength(200, ErrorMessage = "Sector can't exceed 200 characters")]
        public string? Sector { get; set; }

        [Column("industry")]
        [StringLength(200, ErrorMessage = "Industry can't exceed 200 characters")]
        public string? Industry { get; set; }

        [Column("sector_en")]
        [StringLength(200, ErrorMessage = "Sector (EN) can't exceed 200 characters")]
        public string? SectorEn { get; set; }

        [Column("industry_en")]
        [StringLength(200, ErrorMessage = "Industry (EN) can't exceed 200 characters")]
        public string? IndustryEn { get; set; }

        [Column("stock_type")]
        [StringLength(50, ErrorMessage = "Stock type can't exceed 50 characters")]
        public string? StockType { get; set; }

        [Column("rank")]
        [Range(0, int.MaxValue, ErrorMessage = "Rank must be >= 0")]
        public int Rank { get; set; }

        [Column("rank_source")]
        [StringLength(200, ErrorMessage = "Rank source can't exceed 200 characters")]
        public string? RankSource { get; set; }

        [Column("reason")]
        [StringLength(255, ErrorMessage = "Reason can't exceed 255 characters")]
        public string? Reason { get; set; }

        // navigation
        public ICollection<WatchList>? WatchLists { get; set; }
    }
}
