using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.FridgeProducts
{
    public class FridgeProductForUpdateViewModel : FridgeProductForManipulationViewModel
    {
        [Required(ErrorMessage = "Id is required field")]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
    }
}