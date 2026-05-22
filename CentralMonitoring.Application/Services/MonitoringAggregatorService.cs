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
    public class MonitoringAggregatorService
    {
        private readonly ISiteClient _siteClient;

        public MonitoringAggregatorService(ISiteClient siteClient)
        {
            _siteClient = siteClient;
        }

        public async Task<IEnumerable<SiteStatusDto>> AggregateSiteStatusesAsync(
            IEnumerable<Site> sites,
            CancellationToken cancellationToken = default)
        {
            var tasks = sites.Select(async s =>
            {
                var dto = new SiteStatusDto
                {
                    SiteId = s.Id,
                    SiteName = s.Name,
                    Description = s.Description,
                    BaseUrl = s.BaseUrl
                };

                try
                {
                    var configs = await _siteClient.GetMonitoringConfigsAsync(s.BaseUrl, s.ApiKey, cancellationToken);

                    dto.MonitoringConfigs = configs.Select(c => new MonitoringConfigDto
                    {
                        Name = c.Name,
                        Description = c.Description,
                        Config = c.Config,
                        BuildingIds = c.BuildingIds,
                        BuildingNames = c.BuildingNames
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
