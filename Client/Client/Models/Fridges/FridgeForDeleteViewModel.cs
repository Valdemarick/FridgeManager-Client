using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.Fridges
{
    public class FridgeForDeleteViewModel
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
    }
}