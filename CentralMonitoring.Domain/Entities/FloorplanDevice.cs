using System;

namespace CentralMonitoring.Domain.Entities
{
    public class FloorplanDevice : BaseEntity
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
        public MinimalAccessCctv? AccessCctv { get; set; }
        public MinimalAccessControl? AccessControl { get; set; }
        public MinimalMaskedArea? FloorplanMaskedArea { get; set; }
    }

    public class MinimalFloorplan
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? FloorplanImage { get; set; }
    }

    public class MinimalBleReader
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Ip { get; set; }
        public string? Gmac { get; set; }
        public bool? ForceReading { get; set; }
        public decimal? ForceRadiusMeter { get; set; }
        public decimal? ForceRadiusThreshold { get; set; }
        public Guid BrandId { get; set; }
    }

    public class MinimalAccessCctv
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Rtsp { get; set; }
        public Guid? IntegrationId { get; set; }
    }

    public class MinimalAccessControl
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? BrandId { get; set; }
        public string? Channel { get; set; }
    }

    public class MinimalMaskedArea
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ColorArea { get; set; }
        public string? AreaShape { get; set; }
        public Guid FloorplanId { get; set; }
        public Guid FloorId { get; set; }
        public string? RestrictedStatus { get; set; }
    }
}
