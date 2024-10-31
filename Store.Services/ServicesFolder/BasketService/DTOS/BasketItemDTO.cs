using System.ComponentModel.DataAnnotations;

namespace Store.Services.ServicesFolder.BasketService.DTOS
{
    public class BasketItemDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must be Greater Then Zero")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Quantity Must be between 1 To 10 items ")]
        public int Quentity { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}