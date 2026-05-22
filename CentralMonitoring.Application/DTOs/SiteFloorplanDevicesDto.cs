using System;
using System.Collections.Generic;

namespace CentralMonitoring.Application.DTOs
{
    public class SiteFloorplanDevicesDto
    {
        public Guid SiteId { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string OverallStatus { get; set; } = "Offline";
        public List<FloorplanDeviceDto> FloorplanDevices { get; set; } = new();
        public string? ErrorMessage { get; set; }
    }
}
