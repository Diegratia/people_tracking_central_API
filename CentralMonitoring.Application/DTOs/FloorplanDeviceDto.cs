using System;
using CentralMonitoring.Domain.Entities;

namespace CentralMonitoring.Application.DTOs
{
    public class FloorplanDeviceDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? DeviceStatus { get; set; }
        public float? PosX { get; set; }
        public float? PosY { get; set; }
        public float? PosPxX { get; set; }
        public float? PosPxY { get; set; }
        public Guid? ReaderId { get; set; }
        public Guid? AccessCctvId { get; set; }
        public Guid? AccessControlId { get; set; }
        public Guid FloorplanId { get; set; }
        public Guid? FloorplanMaskedAreaId { get; set; }
        public string? Path { get; set; }

        public MinimalFloorplan? Floorplan { get; set; }
        public MinimalBleReader? Reader { get; set; }
        // public MinimalAccessCctv? AccessCctv { get; set; }
        // public MinimalAccessControl? AccessControl { get; set; }
        public MinimalMaskedArea? FloorplanMaskedArea { get; set; }
    }
}
