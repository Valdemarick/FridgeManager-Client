using System;

namespace Domain.Entities.FridgeProduct
{
    public class FridgeProductForCreation
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
    }
}