using System;

namespace Domain.Entities.FridgeProduct
{
    public class FridgeProduct
    {
        public Guid Id { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
    }
}