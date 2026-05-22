using System;
using System.Collections.Generic;

namespace CentralMonitoring.Domain.Entities
{
    public class MonitoringConfigInfo : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Config { get; set; } = string.Empty;
        public List<Guid> BuildingIds { get; set; } = new();
        public List<string> BuildingNames { get; set; } = new();
    }
}
