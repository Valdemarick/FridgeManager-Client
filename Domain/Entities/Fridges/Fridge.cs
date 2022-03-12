using System;

namespace Domain.Entities.Fridges
{
    public class Fridge
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public string Manufacturer { get; set; }
        public int? ProductionYear { get; set; }
        public string Description { get; set; }
    }
}