using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("quotes")]
    public class Quote
    {
        [Key]
        [Column("quote_id")]
        public int QuoteId { get; set; }

        [Column("stock_id")]
        [ForeignKey("Stock")]
        public int StockId { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("change", TypeName = "decimal(18,2)")]
        public decimal Change { get; set; }

        [Required]
        [Column("percent_change", TypeName = "decimal(18,2)")]
        public decimal PercentChange { get; set; }

        [Required]
        [Column("volume")]
        public int Volume { get; set; }

        [Required]
        [Column("time_stamp")]
        public DateTime TimeStamp { get; set; }

        // navigation
        public Stock? Stock { get; set; }
    }
}
