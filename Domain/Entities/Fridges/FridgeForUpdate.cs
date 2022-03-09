using System;

namespace Domain.Entities.Fridges
{
    public class FridgeForUpdate : FridgeForManipulation
    {
        public Guid Id { get; set; }
    }
}