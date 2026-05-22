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
    [Route("api/floor")]
    public class FloorController : ControllerBase
    {
        private readonly BuildingAggregatorService _aggregatorService;
        private readonly IConfiguration _configuration;

        public FloorController(
            BuildingAggregatorService aggregatorService,
            IConfiguration configuration)
        {
            _aggregatorService = aggregatorService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetFloors(CancellationToken cancellationToken)
        {
            var sites = new List<Site>();
            _configuration.GetSection("Sites").Bind(sites);

            var activeSites = sites.FindAll(s => s.IsEnabled);
            var results = await _aggregatorService.GetFlatFloorsAsync(activeSites, cancellationToken);
            
            return Ok(new
            {
                Success = true,
                Msg = "Floors retrieved successfully",
                Collection = new {
                        Data = results
                    },
                Code = 200
            });
        }
    }
}
