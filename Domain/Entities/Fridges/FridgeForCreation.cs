using System;

namespace Domain.Entities.Fridges
{
    public class FridgeForCreation
    {
        public Guid FridgeModelId { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
    }
}