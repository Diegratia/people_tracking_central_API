using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralMonitoring.Domain.Entities;

namespace CentralMonitoring.Application.DTOs
{
    public class SiteLatestPositionDto
    {
        public Guid SiteId { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string OverallStatus { get; set; } = "Offline";
        public List<LatestPositionDto> LatestPositions { get; set; } = new();
        public string? ErrorMessage { get; set; }
    }
}