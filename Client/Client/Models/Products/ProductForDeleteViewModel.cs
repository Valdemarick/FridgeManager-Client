using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.Products
{
    public class ProductForDeleteViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
    }
}