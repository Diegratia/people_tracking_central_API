using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CentralMonitoring.Application.Services;
using CentralMonitoring.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using CentralMonitoring.Application.DTOs;
using Microsoft.Extensions.Configuration;

namespace CentralMonitoring.Presentation.Controllers
{
    [ApiController]
    [Route("api/analytics")]
    [Route("api/tracking-analytics")]
    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsAggregatorService _aggregatorService;
        private readonly IConfiguration _configuration;

        public AnalyticsController(
            AnalyticsAggregatorService aggregatorService,
            IConfiguration configuration)
        {
            _aggregatorService = aggregatorService;
            _configuration = configuration;
        }

        [HttpGet("latest-position")]
        [HttpGet("card-summary")]
        public async Task<IActionResult> GetCardSummary(CancellationToken cancellationToken)
        {
            var filter = new TrackingAnalyticsFilter
            {
                TimeRange = "today"
            };

            var sites = new List<Site>();
            _configuration.GetSection("Sites").Bind(sites);

            var activeSites = sites.FindAll(s => s.IsEnabled);
            var results = await _aggregatorService.AggregateSiteAnalyticsAsync(activeSites, filter, cancellationToken);
            
            return Ok(new
            {
                Success = true,
                Msg = "Latest positions retrieved successfully",
                Collection = new {
                        Data = results
                    },
                Code = 200
            });
        }
    }
}
