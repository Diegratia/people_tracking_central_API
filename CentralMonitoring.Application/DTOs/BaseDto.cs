using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CentralMonitoring.Application.DTOs
{
    public class BaseDto
    {
        [JsonPropertyOrder(-10)]
        public Guid Id { get; set; }
        public Guid? ApplicationId { get; set; }
    }
}