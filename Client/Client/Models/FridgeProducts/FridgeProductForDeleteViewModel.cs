using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.FridgeProducts
{
    public class FridgeProductForDeleteViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
    }
}