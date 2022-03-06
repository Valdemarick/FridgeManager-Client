using System;

namespace Domain.Entities.Products
{
    public class ProductForUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}