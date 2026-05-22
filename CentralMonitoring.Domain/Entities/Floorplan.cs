using System;

namespace CentralMonitoring.Domain.Entities
{
    public class Floorplan : BaseEntity
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
