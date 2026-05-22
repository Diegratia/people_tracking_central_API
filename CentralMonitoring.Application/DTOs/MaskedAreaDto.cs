using System;

namespace CentralMonitoring.Application.DTOs
{
    public class MaskedAreaDto : BaseDto
    {
        public Guid FloorplanId { get; set; }
        public Guid FloorId { get; set; }
        public string? Name { get; set; }
        public string? AreaShape { get; set; }
        public string? ColorArea { get; set; }
        public string? RestrictedStatus { get; set; }
        public bool? AllowFloorChange { get; set; }
        public bool? IsAssemblyPoint { get; set; }
        public int? Status { get; set; }
    }
}
