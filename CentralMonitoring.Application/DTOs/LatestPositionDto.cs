using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralMonitoring.Application.DTOs
{
    public class LatestPositionDto
    {
        public Guid? PersonId => VisitorId ?? MemberId ?? SecurityId;
        public string? PersonName => VisitorName ?? MemberName ?? SecurityName;
        public string PersonType =>
                    VisitorId.HasValue ? "Visitor" :
                    MemberId.HasValue ? "Member" :
                    SecurityId.HasValue ? "Security" :
                    "Unknown";
        public string? IdentityId { get; set; }
        public Guid? CardId { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? BleCardNumber { get; set; }
        public Guid? VisitorId { get; set; }
        public string? VisitorName { get; set; }
        public Guid? MemberId { get; set; }
        public string? MemberName { get; set; }
        public Guid? SecurityId { get; set; }
        public string? SecurityName { get; set; }

        // Location info (last detected)
        public Guid? BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public Guid? FloorId { get; set; }
        public string? FloorName { get; set; }
        public Guid? FloorplanId { get; set; }
        public string? FloorplanName { get; set; }
        public string? FloorplanImage { get; set; }
        public Guid? AreaId { get; set; }
        public string? AreaName { get; set; }
        public float LastX { get; set; }
        public float LastY { get; set; }
        public DateTime? LastDetectedAt { get; set; }
    }
}