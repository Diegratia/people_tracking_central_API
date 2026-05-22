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
    public class BuildingAggregatorService
    {
        private readonly ISiteClient _siteClient;

        public BuildingAggregatorService(ISiteClient siteClient)
        {
            _siteClient = siteClient;
        }

        public async Task<IEnumerable<SiteStatusDto>> AggregateBuildingStatusesAsync(
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
                    // Only query buildings for this site
                    var buildings = await _siteClient.GetBuildingsAsync(s.BaseUrl, s.ApiKey, cancellationToken);

                    var buildingDtos = new List<BuildingDto>();

                    foreach (var b in buildings)
                    {
                        var bDto = new BuildingDto
                        {
                            Id = b.Id,
                            ApplicationId = b.ApplicationId,
                            Name = b.Name,
                            Image = b.Image,
                            Tag = b.Tag
                        };

                        buildingDtos.Add(bDto);
                    }

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

        public async Task<IEnumerable<SiteBuildingsDto>> GetFlatBuildingsAsync(
            IEnumerable<Site> sites,
            CancellationToken cancellationToken = default)
        {
            var tasks = sites.Select(async s =>
            {
                var dto = new SiteBuildingsDto
                {
                    SiteId = s.Id,
                    SiteName = s.Name,
                    Description = s.Description,
                    BaseUrl = s.BaseUrl
                };

                try
                {
                    var buildings = await _siteClient.GetBuildingsAsync(s.BaseUrl, s.ApiKey, cancellationToken);
                    dto.Buildings = buildings.ToList();
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

        public async Task<IEnumerable<SiteFloorsDto>> GetFlatFloorsAsync(
            IEnumerable<Site> sites,
            CancellationToken cancellationToken = default)
        {
            var tasks = sites.Select(async s =>
            {
                var dto = new SiteFloorsDto
                {
                    SiteId = s.Id,
                    SiteName = s.Name,
                    Description = s.Description,
                    BaseUrl = s.BaseUrl
                };

                try
                {
                    var floors = await _siteClient.GetFloorsAsync(s.BaseUrl, s.ApiKey, cancellationToken);
                    dto.Floors = floors.ToList();
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

        public async Task<IEnumerable<SiteFloorplansDto>> GetFlatFloorplansAsync(
            IEnumerable<Site> sites,
            CancellationToken cancellationToken = default)
        {
            var tasks = sites.Select(async s =>
            {
                var dto = new SiteFloorplansDto
                {
                    SiteId = s.Id,
                    SiteName = s.Name,
                    Description = s.Description,
                    BaseUrl = s.BaseUrl
                };

                try
                {
                    var floorplans = await _siteClient.GetFloorplansAsync(s.BaseUrl, s.ApiKey, cancellationToken);
                    dto.Floorplans = floorplans.ToList();
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

        public async Task<IEnumerable<SiteMaskedAreasDto>> GetFlatMaskedAreasAsync(
            IEnumerable<Site> sites,
            CancellationToken cancellationToken = default)
        {
            var tasks = sites.Select(async s =>
            {
                var dto = new SiteMaskedAreasDto
                {
                    SiteId = s.Id,
                    SiteName = s.Name,
                    Description = s.Description,
                    BaseUrl = s.BaseUrl
                };

                try
                {
                    var maskedAreas = await _siteClient.GetMaskedAreasAsync(s.BaseUrl, s.ApiKey, cancellationToken);
                    dto.MaskedAreas = maskedAreas.ToList();
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
