using System;
using System.Collections.Generic;

namespace CentralMonitoring.Application.DTOs
{
    public class FloorDto : BaseDto
    {
        public Guid BuildingId { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
    }
}
