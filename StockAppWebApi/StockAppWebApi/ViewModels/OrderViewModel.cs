using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Stock ID is required")]
        public int StockId { get; set; }

        [Required(ErrorMessage = "Order type is required")]
        [MaxLength(20, ErrorMessage = "Order type cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Order type must be at least 3 characters")]
        public string? OrderType { get; set; }

        [Required(ErrorMessage = "Direction is required")]
        [MaxLength(20, ErrorMessage = "Direction cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Direction must be at least 3 characters")]
        public string? Direction { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        [MinLength(3, ErrorMessage = "Status must be at least 3 characters")]
        public string? Status { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
