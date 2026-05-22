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
    [Route("api/area")]
    public class MaskedAreaController : ControllerBase
    {
        private readonly BuildingAggregatorService _aggregatorService;
        private readonly IConfiguration _configuration;

        public MaskedAreaController(
            BuildingAggregatorService aggregatorService,
            IConfiguration configuration)
        {
            _aggregatorService = aggregatorService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaskedAreas(CancellationToken cancellationToken)
        {
            var sites = new List<Site>();
            _configuration.GetSection("Sites").Bind(sites);

            var activeSites = sites.FindAll(s => s.IsEnabled);
            var results = await _aggregatorService.GetFlatMaskedAreasAsync(activeSites, cancellationToken);
            
            return Ok(new
            {
                Success = true,
                Msg = "Masked areas retrieved successfully",
                Collection = new {
                        Data = results
                    },
                Code = 200
            });
        }
    }
}
