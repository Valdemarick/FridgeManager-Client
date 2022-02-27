using System;

namespace Application.Models
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public string Manufacturer { get; set; }
        public int ProductionYear { get; set; }
    }
}