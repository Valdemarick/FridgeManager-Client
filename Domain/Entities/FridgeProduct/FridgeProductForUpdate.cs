using System;

namespace Domain.Entities.FridgeProduct
{
    public class FridgeProductForUpdate : FridgeProductForManipulation
    {
        public Guid Id { get; set; }
    }
}