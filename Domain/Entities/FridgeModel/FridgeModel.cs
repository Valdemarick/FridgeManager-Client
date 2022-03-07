using System;

namespace Domain.Entities.FridgeModel
{
    public class FridgeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? ProductionYear { get; set; }
    }
}