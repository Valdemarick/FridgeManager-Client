using System;

namespace Domain.Entities.FridgeProduct
{
    public abstract class FridgeProductForManipulation
    {
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}