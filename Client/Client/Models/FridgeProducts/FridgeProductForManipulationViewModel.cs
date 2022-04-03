using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.FridgeProducts
{
    public abstract class FridgeProductForManipulationViewModel
    {
        [Required(ErrorMessage = "FridgeId is required field")]
        [HiddenInput(DisplayValue = false)]
        public Guid FridgeId { get; set; }

        [Required(ErrorMessage = "ProductId is required field")]
        [HiddenInput(DisplayValue = false)]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "ProductCount is required field")]
        [Range(0, 9, ErrorMessage = "ProductCount field can't be less than 0 and more than 9")]
        public int ProductQuantity { get; set; }
    }
}