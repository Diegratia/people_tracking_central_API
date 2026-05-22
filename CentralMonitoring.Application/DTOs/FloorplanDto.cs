using System;
using System.Collections.Generic;

namespace CentralMonitoring.Application.DTOs
{
    public class FloorplanDto : BaseDto
    {
        public string? Name { get; set; }
        public Guid FloorId { get; set; }
        public string? FloorplanImage { get; set; }
        public float PixelX { get; set; }
        public float PixelY { get; set; }
        public float FloorX { get; set; }
        public float FloorY { get; set; }
        public float MeterPerPx { get; set; }
        public int Status { get; set; }
    }
}
