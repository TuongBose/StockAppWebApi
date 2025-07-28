using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required(ErrorMessage = "Stock ID is required")]
        [Column("stock_id")]
        [ForeignKey("Stock")]
        public int StockId { get; set; }
        public Stock? Stock { get; set; }

        [Required(ErrorMessage = "Order type is required")]
        [Column("order_type")]
        [MaxLength(20, ErrorMessage = "Order type cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Order type must be at least 3 characters")]
        public string OrderType { get; set; }

        [Required(ErrorMessage = "Direction is required")]
        [Column("direction")]
        [MaxLength(20, ErrorMessage = "Direction cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Direction must be at least 3 characters")]
        public string Direction { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Column("quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Column("price")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Column("status")]
        [MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Status must be at least 3 characters")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }
    }
}
