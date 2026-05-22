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
    [Route("api/building")]
    public class BuildingController : ControllerBase
    {
        private readonly BuildingAggregatorService _aggregatorService;
        private readonly IConfiguration _configuration;

        public BuildingController(
            BuildingAggregatorService aggregatorService,
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

            var activeSites = sites.FindAll(s => s.IsEnabled);
            var results = await _aggregatorService.AggregateBuildingStatusesAsync(activeSites, cancellationToken);
            
            return Ok(new
            {
                Success = true,
                Msg = "Central Building status aggregated successfully",
                Collection = new {
                        Data = results
                    },
                Code = 200
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildings(CancellationToken cancellationToken)
        {
            var sites = new List<Site>();
            _configuration.GetSection("Sites").Bind(sites);

            var activeSites = sites.FindAll(s => s.IsEnabled);
            var results = await _aggregatorService.GetFlatBuildingsAsync(activeSites, cancellationToken);
            
            return Ok(new
            {
                Success = true,
                Msg = "Buildings retrieved successfully",
                Collection = new {
                        Data = results
                    },
                Code = 200
            });
        }
    }
}
