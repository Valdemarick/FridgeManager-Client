using Microsoft.AspNetCore.Mvc;
using System;

namespace Client.Models.Fridges
{
    public class FridgeForUpdateViewModel : FridgeForManipulationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
    }
}