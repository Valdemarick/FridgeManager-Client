using System;

namespace Domain.Entities.Products
{
    public class ProductForUpdate : ProductForManipulation
    {
        public Guid Id { get; set; }
    }
}