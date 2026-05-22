using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CentralMonitoring.Application.Services;
using CentralMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentralMonitoring.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitoringController : ControllerBase
    {
        private readonly MonitoringAggregatorService _aggregatorService;
        private readonly IConfiguration _configuration;

        public MonitoringController(
            MonitoringAggregatorService aggregatorService,
            IConfiguration configuration)
        {
            _aggregatorService = aggregatorService;
            _configuration = configuration;
        }

        [HttpGet("aggregate")]
        public async Task<IActionResult> GetAggregateStatus(CancellationToken cancellationToken)
        {
            var sites = new List<Site>();
            _configuration.GetSection("Sites").Bind(sites);

            if (sites.Count == 0)
            {
                sites.Add(new Site
                {
                    Id = Guid.Parse("a81836cb-32d6-4447-9759-4d6cb257321e"),
                    Name = "Site A (Default)",
                    Description = "Site Pertama",
                    BaseUrl = "http://localhost:5029",
                    ApiKey = "FujDuGTsyEXVwkKrtRgn52APwAVRGmPOiIRX8cffynDvIW35bJaGeH3NcH6HcSeK",
                    IsEnabled = true
                });
                sites.Add(new Site
                {
                    Id = Guid.Parse("f9294d1f-827c-47ea-bd50-c8f94e772412"),
                    Name = "Site B (Default)",
                    Description = "Site Kedua",
                    BaseUrl = "http://localhost:5030",
                    ApiKey = "FujDuGTsyEXVwkKrtRgn52APwAVRGmPOiIRX8cffynDvIW35bJaGeH3NcH6HcSeK",
                    IsEnabled = true
                });
            }

            var activeSites = sites.FindAll(s => s.IsEnabled);
            var results = await _aggregatorService.AggregateSiteStatusesAsync(activeSites, cancellationToken);
            
            return Ok(new
            {
                Success = true,
                Msg = "Central monitoring status aggregated successfully",
                Collection = new {
                        Data = results
                    },
                Code = 200
            });
        }
    }
}
