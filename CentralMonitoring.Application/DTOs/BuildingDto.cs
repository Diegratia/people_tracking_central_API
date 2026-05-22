using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CentralMonitoring.Application.DTOs
{
    public class BuildingDto : BaseDto
    {   
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }
    }
}