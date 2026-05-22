using System;
using System.Collections.Generic;
using CentralMonitoring.Domain.Entities;

namespace CentralMonitoring.Application.DTOs
{
    public class SiteFloorplansDto
    {
        public Guid SiteId { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string OverallStatus { get; set; } = "Offline";
        public List<Floorplan> Floorplans { get; set; } = new();
        public string? ErrorMessage { get; set; }
    }
}
