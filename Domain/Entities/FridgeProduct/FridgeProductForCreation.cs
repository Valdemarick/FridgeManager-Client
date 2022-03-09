using System;

namespace Domain.Entities.FridgeProduct
{
    public class FridgeProduct
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}