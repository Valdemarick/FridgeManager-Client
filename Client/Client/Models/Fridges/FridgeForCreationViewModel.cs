using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Client.Models.Fridges
{
    public class FridgeForCreationViewModel : FridgeForManipulationViewModel
    {
        public MultiSelectList Products { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}