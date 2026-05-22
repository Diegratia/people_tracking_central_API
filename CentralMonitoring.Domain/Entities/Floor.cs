using System;

namespace CentralMonitoring.Domain.Entities
{
    public class Floor : BaseEntity
    {
        public Guid BuildingId { get; set; }
        public string? Name { get; set; }
    }
}
