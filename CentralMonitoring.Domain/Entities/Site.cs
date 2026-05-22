using System;

namespace CentralMonitoring.Domain.Entities
{
    public class Site
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string? ApiKey { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
