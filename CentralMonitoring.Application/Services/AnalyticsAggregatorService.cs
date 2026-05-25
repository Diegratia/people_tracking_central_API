using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CentralMonitoring.Application.Common.Interfaces;
using CentralMonitoring.Application.DTOs;
using CentralMonitoring.Domain.Entities;

namespace CentralMonitoring.Application.Services
{
    public class AnalyticsAggregatorService
    {
        private readonly ISiteClient _siteClient;
        public AnalyticsAggregatorService(ISiteClient siteClient)
        {
            _siteClient = siteClient;
        }

        public async Task<IEnumerable<SiteLatestPositionDto>> AggregateSiteAnalyticsAsync(
            IEnumerable<Site> sites,
            TrackingAnalyticsFilter filter,
            CancellationToken cancellationToken = default)
        {
            var tasks = sites.Select(async s =>
            {
                var dto = new SiteLatestPositionDto
                {
                    SiteId = s.Id,
                    SiteName = s.Name,
                    Description = s.Description,
                    BaseUrl = s.BaseUrl
                };

                try
                {
                    var analytics = await _siteClient.GetLatestPositionsAsync(s.BaseUrl, filter, s.ApiKey, cancellationToken);

                    dto.LatestPositions = analytics.Select(a => new LatestPositionDto
                    {
                        IdentityId = a.IdentityId,
                        CardId = a.CardId,
                        CardName = a.CardName,
                        CardNumber = a.CardNumber,
                        BleCardNumber = a.BleCardNumber,
                        VisitorId = a.VisitorId,
                        VisitorName = a.VisitorName,
                        MemberId = a.MemberId,
                        MemberName = a.MemberName,
                        SecurityId = a.SecurityId,
                        SecurityName = a.SecurityName,
                        BuildingId = a.BuildingId,
                        BuildingName = a.BuildingName,
                        FloorId = a.FloorId,
                        FloorName = a.FloorName,
                        FloorplanId = a.FloorplanId,
                        FloorplanName = a.FloorplanName,
                        FloorplanImage = a.FloorplanImage,
                        AreaId = a.AreaId,
                        AreaName = a.AreaName,
                        LastX = a.LastX,
                        LastY = a.LastY,
                        LastDetectedAt = a.LastDetectedAt
                    }).ToList();

                    dto.OverallStatus = "Online";
                }
                catch (Exception ex)
                {
                    dto.OverallStatus = "Offline";
                    dto.ErrorMessage = ex.Message;
                }

                return dto;
            });

            return await Task.WhenAll(tasks);
        }
    }
}