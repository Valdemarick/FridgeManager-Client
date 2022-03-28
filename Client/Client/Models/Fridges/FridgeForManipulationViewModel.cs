using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.Fridges
{
    public abstract class FridgeForManipulationViewModel
    {
        [MaxLength(50, ErrorMessage = "Maximum length of 'OwnerName' is 50 characters")]
        public string OwnerName { get; set; }

        [MaxLength(200, ErrorMessage = "Maximum length of 'Description' is 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "'FridgeModel' is required")]
        public Guid FridgeModelId { get; set; }
    }
}