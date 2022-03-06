using System.ComponentModel.DataAnnotations;

namespace Client.Models.Products
{
    public class ProductForCreationViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Maximum length of Name is 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 9, ErrorMessage = "The value of quantity must be in the range between 1 and 9")]
        public int Quantity { get; set; }
    }
}