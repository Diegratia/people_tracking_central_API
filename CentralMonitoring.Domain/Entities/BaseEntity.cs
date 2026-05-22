using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CentralMonitoring.Domain.Entities
{
    public class BaseEntity
    {
        [JsonPropertyOrder(-10)]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid? ApplicationId { get; set; }
    }
}